using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingGameManager : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    public static TestingGameManager Instance { get; private set; }

    //public event EventHandler OnLocalPlayerReadyChanged;
    public event EventHandler OnPlayerDataNetworkListChanged;



    //change this to playercreator
    [SerializeField] private List<Color> playerColorList;

    //private bool isLocalPlayerReady;
    //private Dictionary<ulong, bool> playerReadyDictionary;
    private NetworkList<PlayerData> playerDataNetworkList;




    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        playerDataNetworkList = new NetworkList<PlayerData>();
        playerDataNetworkList.OnListChanged += PlayerDataNetworkList_OnListChanged;
    }

    private void PlayerDataNetworkList_OnListChanged(NetworkListEvent<PlayerData> changeEvent)
    {
        OnPlayerDataNetworkListChanged?.Invoke(this, EventArgs.Empty);
    }


    //private void GameInput_OnInteractAction(object sender, EventArgs e)
    //{
    //    isLocalPlayerReady = true;
    //    OnLocalPlayerReadyChanged?.Invoke(this, EventArgs.Empty);
    //}


    //public bool IsLocalPlayerReady()
    //{
    //    return isLocalPlayerReady;
    //}

    public void StartHost()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += NetworkManager_OnClientConnectedCallback;
        NetworkManager.Singleton.StartHost();
    }

    private void NetworkManager_OnClientConnectedCallback(ulong clientId)
    {
        playerDataNetworkList.Add(new PlayerData
        {
            clientId = clientId,
        });
    }
       

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
                GameObject playerTransform = Instantiate(playerPrefab);
                playerTransform.GetComponent<NetworkObject>().SpawnAsPlayerObject(clinetId, true);
            }
        }
        
    }

    public bool IsPlayerIndexConnected(int playerIndex)
    {
        return playerIndex < playerDataNetworkList.Count;
    }

    public PlayerData GetPlayerDataFromIndex(int playerIndex)
    {
        return playerDataNetworkList[playerIndex];
    }


    //change this to playercreator
    public Color GetPlayerColor(int colorId)
    {
        return playerColorList[colorId];
    }
}
