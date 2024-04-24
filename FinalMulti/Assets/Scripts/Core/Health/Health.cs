using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Health : NetworkBehaviour
{

    [field: SerializeField] public int MaxHealth { get; private set; } = 100;
    public NetworkVariable<int> CurrentHealth = new NetworkVariable<int>();

    private bool isDead;

    public Action<Health> OnDie;
    
    public override void OnNetworkSpawn()
    {
        if (!IsServer) { return; }

        CurrentHealth.Value = MaxHealth;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) { return; }
        if (collision.gameObject.tag == "Bullet")
        {
            CurrentHealth.Value -= 5;
            if (CurrentHealth.Value == 0)
            {
                OnDie?.Invoke(this);
                isDead = true;
            }
        }
        
    }

    

    
}
