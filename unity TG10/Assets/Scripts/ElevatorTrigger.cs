using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiggerTrigger : MonoBehaviour
{
    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponentInParent<jalankanelevator>().YES();
        }
    }
}
