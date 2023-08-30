using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor.PackageManager;
using UnityEngine;

public class TestingPlayer : NetworkBehaviour
{
    public static event EventHandler OnAnyPlayerSpawned;
    public static TestingPlayer LocalInstace {  get; private set; }
    public static List<TestingPlayer> Instances = new List<TestingPlayer>();


    //[SerializeField] private PlayerVisual playerVisual;
    //[SerializeField] private List<Vector3> spawnPositionList;



    private void Start()
    {
        //PlayerData playerData = TestingGameManager.Instance.GetPlayerDataFromClientId(OwnerClientId);
        //playerVisual.SetPlayerColor(TestingGameManager.Instance.GetPlayerColor(playerData.colorId));
        Instances.Add(this);

        if (PlayerParent.Instance)
        {
            transform.SetParent(PlayerParent.Instance.transform, false);
            HidePlayersClientRpc();
            HidePlayersServerRpc();
            //NetworkObject.SpawnAsPlayerObject(this.NetworkObjectId);
        }
        //SpawnPlayerServerRpc(NetworkObjectId);
    }

    //[ServerRpc(RequireOwnership = false)]
    //public void SpawnPlayerServerRpc(ulong ownerId)
    //{
    //    NetworkObject.SpawnAsPlayerObject(ownerId);
    //}

    
    [ClientRpc]
    public void HidePlayersClientRpc()
    {
        if(OwnerClientId == 1 && IsClient)
        {            
            transform.GetChild(0).gameObject.SetActive(true);
        }
        //if(!IsServer)
        //{
        //    transform.GetChild(0).gameObject.SetActive(false);
        //}
    }
    [ServerRpc(RequireOwnership = false)]
    public void HidePlayersServerRpc(ServerRpcParams serverRpcParams = default)
    {
        if (OwnerClientId == 0 && IsServer)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (OwnerClientId == 1 && IsClient)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public static void MoveCharaterToY(float y)
    {
        // moving player prefab to y position after charatercreator screen
        foreach (var item in Instances)
        {
            item.transform.localPosition = new Vector3(0, y, 0);

        }
    }

    private void OnDestroy()
    {
        Debug.Log("destroing "+OwnerClientId);
        Instances.Remove(this);
    }
    private void Update()
    {
        if(!IsOwner || !Application.isFocused) return;
    }


    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            LocalInstace = this;
        }


        //transform.position = spawnPositionList[TestingGameManager.Instance.GetPlayerDataIndexFromClientId(OwnerClientId)];

        OnAnyPlayerSpawned?.Invoke(this, EventArgs.Empty);

    }
}
