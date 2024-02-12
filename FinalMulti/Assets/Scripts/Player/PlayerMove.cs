using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMove : NetworkBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f; 
    [SerializeField] private float jumpForce = 5f;

    private bool canJump = true; 

    void Update()
    {
        if (!IsOwner)
            return;

        
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0) * moveSpeed;
        rb.MovePosition(rb.position + movement * Time.deltaTime);

        
        /*if (inputReader.Jump && canJump)
        {
            Jump();
        }*/
    }

    
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0); 
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
        canJump = false; 
    }

    
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; 
        }
    }*/
}
