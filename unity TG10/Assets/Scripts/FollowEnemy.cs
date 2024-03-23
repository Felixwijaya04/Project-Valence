using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] float agroRange;
    [SerializeField] Transform player;
    public GameObject bar;
    public int distances;
    private void Awake()
    {
        bar.SetActive(false);
    }
    void Update()
    {
        if (enemy != null)
        {
            transform.position = enemy.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y + distances, transform.position.z);
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= agroRange)
            {
                bar.SetActive(true);
            }   else
            {
                bar.SetActive(false);
            }
        }
        
    }

    


}
