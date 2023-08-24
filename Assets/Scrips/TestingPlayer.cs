using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TestingPlayer : NetworkBehaviour
{
    public static event EventHandler OnAnyPlayerSpawned;
    public static TestingPlayer LocalInstace {  get; private set; }


    [SerializeField] private PlayerVisual playerVisual;







    private void Start()
    {
        //PlayerData playerData = TestingGameManager.Instance.GetPlayerDataFromClientId(OwnerClientId);
        //playerVisual.SetPlayerColor(TestingGameManager.Instance.GetPlayerColor(playerData.colorId));
    }


    public override void OnNetworkSpawn()
    {
        if(IsOwner)
        {
            LocalInstace = this;
        }


        OnAnyPlayerSpawned?.Invoke(this, EventArgs.Empty);

    }
}
