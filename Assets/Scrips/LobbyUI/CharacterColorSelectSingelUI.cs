using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterColorSelectSingelUI : MonoBehaviour
{
    //[SerializeField] private int colorId;
    //[SerializeField] private Image image;
    [SerializeField] private GameObject selectedGameObject;






    private void Awake()
    {
        //GetComponent<Button>().onClick.AddListener(() =>
        //{
        //    TestingGameManager.Instance.ChangePlayerColor(colorId);
        //});
    }


    private void Start()
    {
        TestingGameManager.Instance.OnPlayerDataNetworkListChanged += TestingGameManager_OnPlayerDataNetworkListChanged;
        CharacterSelectReady.Instance.OnReadyChanged += CharacterSelectReady_OnReadyChanged;
        //image.color = TestingGameManager.Instance.GetPlayerColor(colorId);
        UpdatedIsSelected();
    }

    private void CharacterSelectReady_OnReadyChanged(object sender, System.EventArgs e)
    {
        UpdatedIsSelected(); ;
    }

    private void TestingGameManager_OnPlayerDataNetworkListChanged(object sender, System.EventArgs e)
    {
        UpdatedIsSelected();
    }

    private void UpdatedIsSelected()
    {
        //if(TestingGameManager.Instance.GetPlayerData().colorId == colorId)
        //{
        //    selectedGameObject.SetActive(true);
        //}
        //else 
        //{ 
        //    selectedGameObject.SetActive(false); 
        //}
    }
}
