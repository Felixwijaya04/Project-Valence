using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public GameObject enemy;
    private void Awake()
    {
        /*gameObject.SetActive(false);*/
    }
    void Update()
    {
        transform.position = enemy.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletDamage bullet = collision.gameObject.GetComponent<BulletDamage>();
        if (bullet != null)
        {
            gameObject.SetActive(true);
        }
    }*/


}
