using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jalankanelevator : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void YES()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 0.5f;
        rb.mass = 10f;
    }
}
