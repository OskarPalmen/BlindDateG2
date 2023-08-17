using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class TestingNetcodeUI : MonoBehaviour
{
    //[SerializeField] private Button startHostBtn;
    //[SerializeField] private Button startClientBtn;
    //[SerializeField] private Button startServerBtn;
    [SerializeField] private string gamePlaySceneName = "AxelGPMPGameplay";


    private void Awake()
    {
        //startHostBtn.onClick.AddListener(() =>
        //{
        //    ClickHost();
        //});


        //startClientBtn.onClick.AddListener(() =>
        //{
        //    ClickClient();
        //});

        //startServerBtn.onClick.AddListener(() =>
        //{
        //    ClickServer();
        //});
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
        NetworkManager.Singleton.SceneManager.LoadScene(gamePlaySceneName, LoadSceneMode.Single);
        Hide();
    }

    public void ClickServer()
    {
        Debug.Log("HOST");
        NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.SceneManager.LoadScene(gamePlaySceneName, LoadSceneMode.Single);
        Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}