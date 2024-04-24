using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    private float horizontal;
    private float speed = 20f;
    private float jumpingPower = 20f;
    private bool isFacingRight = true;
    private bool doubleJump;
    private float doubleJumpPower = 16f;
    private Animator anim;

    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public AudioSource Jumpsound;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // public override void OnNetworkSpawn()
    // {
    //     if (!IsOwner) { return; }
    //     inputReader.MoveEvent += HandleMove;
    // }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        anim.SetBool("run", horizontal != 0);
        anim.SetBool("grounded", IsGrounded());
        
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            if (!IsOwner) { return; }
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                if (!IsOwner) { return; }
                rb.velocity = new Vector2(rb.velocity.x, doubleJump ? doubleJumpPower :jumpingPower);
                
                doubleJump = !doubleJump;
                Jumpsound.PlayOneShot(Jumpsound.clip);
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            if (!IsOwner) { return; }
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (!IsOwner) { return; }
        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
   
}