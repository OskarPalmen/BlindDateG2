using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class TestingNetcodeUI : MonoBehaviour
{
    [SerializeField] private Button startHostBtn;
    [SerializeField] private Button startClientBtn;


    private void Awake()
    {
        startHostBtn.onClick.AddListener(() =>
        {
            ClickHost();
        });


        startClientBtn.onClick.AddListener(() =>
        {
            ClickClient();
        });
    }

    public void ClickClient()
    {
        Debug.Log("CLIENT");
        NetworkManager.Singleton.StartClient();
        Hide();
    }

    public void ClickHost()
    {
        Debug.Log("HOST");
        NetworkManager.Singleton.StartHost();
        Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}