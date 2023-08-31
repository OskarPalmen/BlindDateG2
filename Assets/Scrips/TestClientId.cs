using System.Collections;
using UnityEngine;
using Unity.Netcode;


public class TestClientId : NetworkBehaviour
{

    [SerializeField] private NetworkObject player0;
    [SerializeField] private NetworkObject player1;

    // Start is called before the first frame update

    private void Awake()
    {
        SetPlayerIDsServerRpc();
        //HidePlayersClientRpc();


    }
    void Start()
    {

        if (PlayerParent.Instance)
        {
            transform.SetParent(PlayerParent.Instance.transform, false);
        }
    }

    [ClientRpc]
    public void HidePlayersClientRpc()
    {
        if (IsLocalPlayer)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (!IsOwner || !Application.isFocused) return;
    }

    [ServerRpc(RequireOwnership = false)]
    public void SetPlayerIDsServerRpc(ServerRpcParams serverRpcParams = default)
    {
        player0.GetComponent<NetworkObject>().SpawnWithOwnership(0);
        player1.GetComponent<NetworkObject>().SpawnWithOwnership(1);
        if (IsHost)
        {

            //player0 = GetComponent<NetworkObject>().ChangeOwnership();
        }
        if (IsClient)
        {

            //player1 = GetComponent<NetworkObject>().ChangeOwnership();
        }
    }

    [ClientRpc]
    public void HidePlayersClientRpc(ulong clientId)
    {
        if (IsClient)
        {
            //player1.transform.GetChild(0).gameObject.SetActive(true);
            player1.GetComponentInChildren<GameObject>().SetActive(true);
        }
    }
}
