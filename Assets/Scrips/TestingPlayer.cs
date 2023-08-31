using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class TestingPlayer : NetworkBehaviour
{
    public static event EventHandler OnAnyPlayerSpawned;
    public static TestingPlayer LocalInstace { get; private set; }
    public static List<TestingPlayer> Instances = new List<TestingPlayer>();
    public Image hair;
    public Image facialHair;
    public Image eyes;
    public Image mouth;
    public Image freckles;
    public Image hat;
    public Image accessories;
    public Image skin;
    public Image body;



    private void Start()
    {
        //PlayerData playerData = TestingGameManager.Instance.GetPlayerDataFromClientId(OwnerClientId);    
        Instances.Add(this);

        if (this.IsOwner)
        {
            LocalInstace = this;
        }

        if (PlayerParent.Instance)
        {
            transform.SetParent(PlayerParent.Instance.transform, false);


            transform.GetChild(0).gameObject.SetActive(OwnerClientId == NetworkManager.Singleton.LocalClientId);

            MoveCharaterToX(-385);
        }
    }

    public static void MoveCharaterToY(float y)
    {
        // moving player prefab to y position after charatercreator screen
        foreach (var item in Instances)
        {
            item.transform.localPosition = new Vector3(0, y, 0);
            item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        }
    }

    public static void MoveCharaterToX(float x)
    {
        // moving player prefab to y position after charatercreator screen
        foreach (var item in Instances)
        {
            item.transform.localPosition = new Vector3(x, 0, 0);
            //item.transform.position = new Vector3(x, 0, 0);


        }
    }

    private void OnDestroy()
    {
        Debug.Log("destroing " + OwnerClientId);
        Instances.Remove(this);
    }
    private void Update()
    {
        if (!IsOwner || !Application.isFocused) return;
    }


    public override void OnNetworkSpawn()
    {


        //transform.position = spawnPositionList[TestingGameManager.Instance.GetPlayerDataIndexFromClientId(OwnerClientId)];

        OnAnyPlayerSpawned?.Invoke(this, EventArgs.Empty);

    }
}
