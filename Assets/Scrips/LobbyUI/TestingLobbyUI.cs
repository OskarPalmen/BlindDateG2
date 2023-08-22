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
    [SerializeField] private Button backButton;


    [SerializeField] private string characterSelectScene = "AxelGPMPCharacterSelectScene";



    private void Awake()
    {
        creatGameButton.onClick.AddListener(() =>
        {
            //NetworkManager.Singleton.StartHost();
            TestingGameManager.Instance.StartHost();
            NetworkManager.Singleton.SceneManager.LoadScene(characterSelectScene, LoadSceneMode.Single);
        });

        joinGameButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });

        backButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
        });
    }
}
