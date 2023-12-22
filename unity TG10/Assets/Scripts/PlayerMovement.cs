using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] float Walkspeed = 20f;
    [SerializeField] float runningSpeed = 30f;
    [SerializeField] float silentWalkSpeed = 10f;

    float currentSpeed;
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");


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

        
    }

    private void FixedUpdate()
    {
        currentSpeed = Walkspeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runningSpeed;
            Debug.Log("running");
        } else if (Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed = silentWalkSpeed;
            Debug.Log("silent");
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
