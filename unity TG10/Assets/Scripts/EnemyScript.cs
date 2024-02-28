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
    [SerializeField] float maxHealth;

    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
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
            // play atk animation
            
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
            transform.Rotate(0f, 180f, 0f);
        }
        else if(transform.position.x > player.position.x) 
        {
            //move left
            rb2d.velocity = new Vector2 (-moveSpeed, 0);
            transform.Rotate(0f, 180f, 0f);
        }
    }
    private void flip()
    {
        // gtw cara flip ny
    }
}
