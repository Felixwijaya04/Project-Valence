using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackDist;
    [SerializeField] Transform PatrolPoint;
    [SerializeField] float patrolRange;


    public Animator animator;
    public int health = 100;

    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GetComponent<EnemyPatrol>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        float patrol = Vector2.Distance(transform.position, PatrolPoint.position);

        print("dist: " + distance);
        if(distance < agroRange)
        {
            //chase
            Chase();
            
        }
        else
        {
            //stop
            StopChasing();
        }
        if(distance < attackDist)
        {
            animator.SetTrigger("Attack");
            
        }
        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (patrol > patrolRange)
        {
            GetComponent<EnemyPatrol>().enabled = true;
            GetComponent<EnemyScript>().enabled = false;
        }

    }

    void StopChasing()
    {
        rb2d.velocity = new Vector2 (0 , -moveSpeed);
    }

    void Chase()
    {
        if(transform.position.x < player.position.x)
        {
            //move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            /*transform.Rotate(0f, 180f, 0f);*/
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if(transform.position.x > player.position.x) 
        {
            //move left
            rb2d.velocity = new Vector2 (-moveSpeed, 0);
            /*transform.Rotate(0f, -180f, 0f);*/
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        
    }
  

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
