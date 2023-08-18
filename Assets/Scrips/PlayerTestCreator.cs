using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayerTestCreator : MonoBehaviour
{
    public GameObject Player;

    public Button colorbutton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = colorbutton.GetComponent<Button>();
        btn.onClick.AddListener(ColorChangeServerRpc);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ColorChangeServerRpc()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Player.GetComponentInChildren<Renderer>().sharedMaterial.color = color;
    }
}
