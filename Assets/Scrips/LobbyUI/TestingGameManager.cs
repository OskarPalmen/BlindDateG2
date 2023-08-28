using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestingGameManager : NetworkBehaviour
{
    [SerializeField] private NetworkObject playerPrefab;
    public static TestingGameManager Instance { get; private set; }

    //public event EventHandler OnLocalPlayerReadyChanged;
    public event EventHandler OnPlayerDataNetworkListChanged;

    //public RectTransform panel;



    //change this to playercreator
    //[SerializeField] private List<Color> playerColorList;

    //private bool isLocalPlayerReady;
    private Dictionary<ulong, bool> playerReadyDictionary;
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
            //colorId = GetFirstUnusedColorId(),
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
            foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
            {
                //spawning in the player prefab

                NetworkObject playerTransform = Instantiate(playerPrefab, new Vector3 (0,0 ,0) ,Quaternion.identity,PlayerParent.Instance.transform);
                playerTransform.transform.localPosition = new Vector3(0, -300f, 0);
                playerTransform.SpawnAsPlayerObject(clientId, true);
                playerTransform.GetComponent<TestingPlayer>().HidePlayersClientRpc();

            }
        }
        
    }


    public bool IsPlayerIndexConnected(int playerIndex)
    {
        return playerIndex < playerDataNetworkList.Count;
    }
    public PlayerData GetPlayerDataFromClientId(ulong clientId)
    {
        foreach (PlayerData playerData in playerDataNetworkList)
        {
            if (playerData.clientId == clientId)
            {
                return playerData;
            }
        }
        return default;
    }


    public int GetPlayerDataIndexFromClientId(ulong clientId)
    {
        for(int i = 0; i < playerDataNetworkList.Count; i++)        
        {
            if (playerDataNetworkList[i].clientId == clientId)
            {
                return i;
            }
        }
        return -1;
    }

    public PlayerData GetPlayerData()
    {
        return GetPlayerDataFromClientId(NetworkManager.Singleton.LocalClientId);
    }

    public PlayerData GetPlayerDataFromIndex(int playerIndex)
    {
        return playerDataNetworkList[playerIndex];
    }



    
    //change this to playercreator
    //public Color GetPlayerColor(int colorId)
    //{
    //    return playerColorList[colorId];
    //}
    

    //public void ChangePlayerColor(int colorId)
    //{
    //    ChangePlayerColorServerRpc(colorId);
    //}

    //[ServerRpc(RequireOwnership = false)]
    //private void ChangePlayerColorServerRpc(int colorId, ServerRpcParams serverRpcParams = default)
    //{
    //    if(!IsColorAvailable(colorId))
    //    {
    //        return;
    //    }
    //    int playerDataindex = GetPlayerDataIndexFromClientId(serverRpcParams.Receive.SenderClientId);

    //    ////grabbing
    //    //PlayerData playerData = playerDataNetworkList[playerDataindex];
    //    ////modifing
    //    //playerData.colorId = colorId;
    //    ////add it
    //    //playerDataNetworkList[playerDataindex] = playerData;
    //}

    //private bool IsColorAvailable (int colorId)
    //{
    //    foreach (PlayerData playerData in playerDataNetworkList)
    //    {
    //        if (playerData.colorId == colorId)
    //            return false;
    //    }
    //    return true;
    //}

    //private int GetFirstUnusedColorId()
    //{
    //    for(int i = 0; i < playerColorList.Count; i++)
    //    {
    //        if(IsColorAvailable(i))
    //        {
    //            return i;
    //        }
    //    }
    //    //can add to see if player have same color/skins
    //    return -1;
    //}
}
