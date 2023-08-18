using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingGameManager : NetworkBehaviour
{
    [SerializeField] private Transform playerPrefab;
    public static TestingGameManager Instance { get; private set; }

    //public event EventHandler OnLocalPlayerReadyChanged;

    //private bool isLocalPlayerReady;
    //private Dictionary<ulong, bool> playerReadyDictionary;




    //private void Awake()
    //{
    //    playerReadyDictionary = new Dictionary<ulong, bool>();
    //}


    //private void GameInput_OnInteractAction(object sender, EventArgs e)
    //{
    //    isLocalPlayerReady = true;
    //    OnLocalPlayerReadyChanged?.Invoke(this, EventArgs.Empty);
    //}


    //public bool IsLocalPlayerReady()
    //{
    //    return isLocalPlayerReady;
    //}


    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SceneManager_OnLoadEventComplete;
        }
    }

    private void SceneManager_OnLoadEventComplete(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        if (NetworkManager.Singleton.ConnectedClientsIds.Count >= 2)
        {
            foreach (ulong clinetId in NetworkManager.Singleton.ConnectedClientsIds)
            {
                //spawning in the player prefab
                Transform playerTransform = Instantiate(playerPrefab);
                playerTransform.GetComponent<NetworkObject>().SpawnAsPlayerObject(clinetId, true);
            }
        }
        
    }
}
