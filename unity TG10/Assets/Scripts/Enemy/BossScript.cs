using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackDist;
    [SerializeField] float damage;


    public bool akukena = false;
    public Animator animator;
    public PlayerMovement PM;
    public EnemyBarValue healthBar;
    public Canvas canvas;
    public bool attack = false;


    Rigidbody2D rb2d;
    void Start()
    {
        /*healthBar.SetMaxHealth(health);*/
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        /*print("dist: " + distance);*/
        if (distance < agroRange)
        {
            //chase
            Chase();
            Debug.Log("kejar");

        }
        else if (distance > agroRange && akukena == false)
        {
            //stop
            StopChasing();
        }
        if (distance <= attackDist)
        {
            attack = true;
            GetComponent<BossAttack>().enabled = true;

        }

        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

    }

    void StopChasing()
    {
        /*rb2d.velocity = new Vector2(0, -moveSpeed);*/
    }

    void Chase()
    {
        if (transform.position.x < player.position.x)
        {
            //move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.x > player.position.x)
        {
            //move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit a player");
            PM.TakeDamage(3);
        }

    }
}
