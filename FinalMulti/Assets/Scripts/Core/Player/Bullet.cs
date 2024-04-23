using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Bullet : NetworkBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    // Update is called once per frame
    void Update() => transform.right = rb.velocity;

}
