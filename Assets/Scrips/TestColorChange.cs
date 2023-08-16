using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class TestColorChange : NetworkBehaviour
{

    public GameObject Player;
    public Button colorbutton;

    private NetworkVariable<int> randomNumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    // Start is called before the first frame update
    void Start()
    {
        Button btn = colorbutton.GetComponent<Button>();
        btn.onClick.AddListener(ColorChange);
    }
    public void Update()
    {
        Debug.Log(OwnerClientId + "; randomNumber" + randomNumber.Value);
        if (!IsOwner)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            randomNumber.Value = Random.Range(0, 100);
        }

    }

    //[ServerRpc(RequireOwnership = false)]
    public void ColorChange()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Player.GetComponentInChildren<Renderer>().sharedMaterial.color = color;
    }

}
