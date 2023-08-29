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
            transform.SetParent(PlayerParent.Instance.transform, true);
        }

    }

    
    [ClientRpc]
    public void HidePlayersClientRpc()
    {
        if(IsLocalPlayer)
        {            
            transform.GetChild(0).gameObject.SetActive(true);
        }


    }

    private void OnDestroy()
    {
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
