using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class TestingLobbyUI : MonoBehaviour
{
    [SerializeField] private Button creatGameButton;
    [SerializeField] private Button joinGameButton;


    [SerializeField] private string characterSelectScene = "AxelGPMPCharacterSelectScene";



    private void Awake()
    {
        creatGameButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            NetworkManager.Singleton.SceneManager.LoadScene(characterSelectScene, LoadSceneMode.Single);
        });

        joinGameButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }


    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
