using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Default Settings")]
    private float horizontal;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    public Animator animator;
    private GameObject currentTeleporter;
    private bool isGrounded;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public static bool isMoving = false;
    public int maxarmor = 100;
    public int currentarmor = 0;
    public BarArmor barArmor;
    /*private int FacingSign = 0;*/

    [Header("Player Manual Settings")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] float Walkspeed ;
    [SerializeField] float runningSpeed ;
    [SerializeField] float silentWalkSpeed = 10f;

    float currentSpeed;

    [Header("Audio Reference")]
    public AudioClip walk, run;
    AudioSource audioSource;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxhealth(maxHealth);
        audioSource = GetComponent<AudioSource>();
        barArmor.setArmor(maxarmor);
        barArmor.setCurrentarmor(currentarmor);
    }

    void Update()
    {
        if(Time.timeScale != 0f)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal == 0)
            {
                /*Debug.Log(horizontal);*/
                isMoving = false;
                audioSource.Stop();
            }
            else if (horizontal != 0)
            {
                isMoving = true;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

            }

            animator.SetFloat("Speed", (isFacingRight ? 1 : -1) * rb.velocity.x);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x > transform.position.x && !isFacingRight)
            {
                flip();
            }
            else if (mousePos.x < transform.position.x && isFacingRight)
            {
                flip();
            }


            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                TakeDamage(5);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentarmor !> 0)
        {
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
        }
        currentarmor -= damage;
        
    }

    private void FixedUpdate()
    {
        
        currentSpeed = Walkspeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runningSpeed;
            /*Debug.Log("running");*/
        } else if (Input.GetKey(KeyCode.LeftControl) && isGrounded)
        {
            currentSpeed = silentWalkSpeed;
            /*Debug.Log("silent");*/
        }
        // memanggil return value dari script shooting
        if (Shooting.Pressing() == true)
        {
            currentSpeed = Walkspeed;
            /*Debug.Log("stop moving");*/
        }
        Walk(currentSpeed);

        if (currentSpeed == Walkspeed)
        {
            audioSource.clip = walk;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else if (currentSpeed == runningSpeed)
        {
            audioSource.clip = run;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }

        //isGrounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("isGround", isGrounded);
        
    }

    
    void Walk(float currentspeed)
    {
        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);
    }

    // private bool isGrounded()
    // {
    //     return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    // }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
       /* Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;*/
        
    }

    
}
