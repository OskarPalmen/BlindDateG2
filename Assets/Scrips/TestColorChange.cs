using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEditor;

public class TestColorChange : NetworkBehaviour
{

    public GameObject Player;
    //public Button colorbutton;

    private NetworkVariable<int> randomNumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public override void OnNetworkSpawn()
    {
        randomNumber.OnValueChanged += (int previousValue, int newValue) => 
        { 
            Debug.Log(OwnerClientId + "; randomNumber" + randomNumber.Value);
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        //Button btn = colorbutton.GetComponent<Button>();
        //btn.onClick.AddListener(ColorChange);
    }
    public void Update()
    {
        
        if (!IsOwner)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            ColorChange();
            
        }

    }

    //[ServerRpc(RequireOwnership = false)]
    public void ColorChange()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Player.GetComponentInChildren<Renderer>().sharedMaterial.color = color;

        randomNumber.Value = Random.Range(0, 100);
    }

    public void Submit()
    {
        PrefabUtility.SaveAsPrefabAsset(Player, "Assets/Prefab/PlayerTestA.prefab");
    }

}
