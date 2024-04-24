using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class RespawnHandler : NetworkBehaviour
{
    [SerializeField] private AventurePlayer playerPrefab;
    

    public override void OnNetworkSpawn()
    {
        if (!IsServer) { return; }
        AventurePlayer[] players = FindObjectsByType<AventurePlayer>(FindObjectsSortMode.None);
        foreach (AventurePlayer player in players)
        {
            HandlePlayerSpawned(player);
        }
        AventurePlayer.OnPlayerSpawned += HandlePlayerSpawned;
        AventurePlayer.OnPlayerDeSpawned += HandlePlayerDespawned;
    }  

    public override void OnNetworkDespawn()
    {
        if (!IsServer) { return; }
        AventurePlayer.OnPlayerSpawned -= HandlePlayerSpawned;
        AventurePlayer.OnPlayerDeSpawned -= HandlePlayerDespawned;
    }
    private void HandlePlayerSpawned(AventurePlayer player)
    {
        player.Health.OnDie += (health) => HandlePlayerDie(player);
    } 
    private void HandlePlayerDespawned(AventurePlayer player)
    {
        player.Health.OnDie -= (health) => HandlePlayerDie(player);
    }
    private void HandlePlayerDie(AventurePlayer player)
    {

        Destroy(player.gameObject);

        StartCoroutine(RespawnPlayer(player.OwnerClientId));
    }

    private IEnumerator RespawnPlayer(ulong ownerClientId)
    {
        yield return null;

        AventurePlayer playerInstance = Instantiate(
            playerPrefab,SpawnPoint.GetRandomSpawnPos(),Quaternion.identity);

        playerInstance.NetworkObject.SpawnAsPlayerObject(ownerClientId);
       
    }
}
