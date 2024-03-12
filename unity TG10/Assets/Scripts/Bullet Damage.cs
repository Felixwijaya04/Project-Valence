using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 40;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
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
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        /*if (collision.gameObject.tag == "Enemy")
        {
            EnemyScript Enemy = GetComponent<EnemyScript>();
            Enemy.TakeDamage(damage);
            Debug.Log("HITTTTTTTTTTTTTT");
        }*/
        Destroy(gameObject);
    }


}
