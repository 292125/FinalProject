using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MoveControll : NetworkBehaviour
{
    [Header("References")] 
    [SerializeField] private InputReader inputreader;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private Rigidbody2D rb;

    [Header("Setting")] 
    [SerializeField] private float movementSpeed = 4f;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { return; }
    }

    public override void OnNetworkDespawn()
    {
        if (!IsOwner) { return; }
    }
}
