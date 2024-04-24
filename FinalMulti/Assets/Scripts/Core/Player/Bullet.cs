using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Bullet : NetworkBehaviour
{
   // [SerializeField] private Collider2D playerCollider;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    // Update is called once per frame
    void Update() => transform.right = rb.velocity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player" )
        {
            Destroy(this.gameObject);
        }
        

        
    }
    
    
    
    
}
