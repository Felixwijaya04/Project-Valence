using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    public Animator animator;
    private GameObject currentTeleporter;
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBar;
    /*private int FacingSign = 0;*/


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] float Walkspeed = 20f;
    [SerializeField] float runningSpeed = 30f;
    [SerializeField] float silentWalkSpeed = 10f;

    float currentSpeed;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxhealth(maxHealth);
    }

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", (isFacingRight ? 1 : -1 ) * rb.velocity.x);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > transform.position.x && !isFacingRight)
        {
            flip();
        }
        else if (mousePos.x < transform.position.x && isFacingRight)
        { 
            flip();
        }


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            TakeDamage(5);
        }
        
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    private void FixedUpdate()
    {
        currentSpeed = Walkspeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runningSpeed;
            Debug.Log("running");
        } else if (Input.GetKey(KeyCode.LeftControl) && isGrounded())
        {
            currentSpeed = silentWalkSpeed;
            Debug.Log("silent");
        }
        // memanggil return value dari script shooting
        if (Shooting.Pressing() == true)
        {
            currentSpeed = Walkspeed;
            Debug.Log("stop moving");
        }
        Walk(currentSpeed);
    }
    void Walk(float currentspeed)
    {
        
        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);
        
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
       /* Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;*/
        
    }

    
}
