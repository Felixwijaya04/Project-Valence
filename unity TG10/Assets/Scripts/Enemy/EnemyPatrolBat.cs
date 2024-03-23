using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBat : MonoBehaviour
{
    [SerializeField] Transform PatrolPoint;
    [SerializeField] float patrolRange;
    [SerializeField] float moveSpeed;
    [SerializeField] float stop;

    public Animator animator;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        float patrol = Vector2.Distance(transform.position, PatrolPoint.position);
        if (patrol > patrolRange)
        {
            Debug.Log("pilip titid");
            Back();
        }
        if (patrol < stop)
        {
            Stop();
            GetComponent<EnemyScriptbat>().enabled = true;
            GetComponent<EnemyScriptbat>().akukena = false;
            GetComponent<EnemyPatrolBat>().enabled = false;
        }

    }

    void Back()
    {
        /*GetComponent<EnemyScript>().enabled = false;*/
        if (transform.position.x < PatrolPoint.position.x)
        {
            //Move Right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.x > PatrolPoint.position.x)
        {
            //move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Stop()
    {
        rb2d.velocity = new Vector2(0, -moveSpeed);
    }
}
