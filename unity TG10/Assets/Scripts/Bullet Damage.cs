using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 40;
    public GameObject HitImpact;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyScript Enemy = GetComponent<EnemyScript>();
            Enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }*/


    public void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        EnemyScriptbat bat = collision.gameObject.GetComponent<EnemyScriptbat>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if(bat != null)
        {
            bat.TakeDamage(damage);
        }

        Instantiate(HitImpact,transform.position, Quaternion.identity);



        Destroy(gameObject);
    }


}
