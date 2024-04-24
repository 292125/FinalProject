using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Cinemachine;
using Unity.Collections;

public class AventurePlayer : NetworkBehaviour
{
    [Header("References")] 
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    

    [Header("Setting")] 
    [SerializeField] private int OwnerPriority = 15;
    
    [field:SerializeField] public Health Health {  get; private set; }

    public NetworkVariable<FixedString32Bytes> PlayerName = new NetworkVariable<FixedString32Bytes>();
    
    [Header("Settings")]
    [SerializeField] private int ownerPriority = 15;

    public static event Action<AventurePlayer> OnPlayerSpawned;
    public static event Action<AventurePlayer> OnPlayerDeSpawned;
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            UserData userData =
                HostSingleton.Instance.GameManager.NetworkServer.GetUserDataByClientId(OwnerClientId);

            PlayerName.Value = userData.userName;
            
            OnPlayerSpawned?.Invoke(this);
        }
        if (IsOwner)
        {
            virtualCamera.Priority = ownerPriority;
        }
        
    }

    public override void OnNetworkDespawn()
    {
        if (IsServer)
        {
            OnPlayerDeSpawned?.Invoke(this);
        }
    }
}