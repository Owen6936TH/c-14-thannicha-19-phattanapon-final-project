using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 10f;
    bool facingRight = true;

    Rigidbody2D r2d;
    Animator anim;

    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700.0f;

    public float JumpBufferTime = 0.5f;
    public float KoyoteTime = 0.5f;
    private float jumpBufferTimeLeft;
    private float koyoteTimeTimeLeft;



    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        koyoteTimeTimeLeft = KoyoteTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferTimeLeft = JumpBufferTime;
        }

        //Debug.Log($"Buffer: {jumpBufferTimeLeft}, Koyote: {koyoteTimeTimeLeft}, Grounded: {grounded}");

        if (CanJump() && jumpBufferTimeLeft > 0)
        {
            r2d.velocity = Vector2.zero;
            grounded = false;
            anim.SetBool("Ground", false);
            r2d.AddForce(new Vector2(0, jumpForce));

            jumpBufferTimeLeft = 0;
            koyoteTimeTimeLeft = -0.25f;
        }

        if (jumpBufferTimeLeft > 0) jumpBufferTimeLeft -= Time.deltaTime;
        if (koyoteTimeTimeLeft > 0.5) koyoteTimeTimeLeft -= Time.deltaTime;
        if (koyoteTimeTimeLeft < 0.5) koyoteTimeTimeLeft += Time.deltaTime;

    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded && koyoteTimeTimeLeft > 0.5)
        {
            Debug.Log("refresh");
            koyoteTimeTimeLeft = KoyoteTime;
        }

        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", r2d.velocity.y);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        r2d.velocity = new Vector2(move * maxSpeed, r2d.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    bool CanJump()
    {
        return grounded || koyoteTimeTimeLeft > 0.5;
    }

}
