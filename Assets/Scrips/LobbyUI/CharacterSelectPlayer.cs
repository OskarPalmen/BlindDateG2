using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectPlayer : MonoBehaviour
{
    [SerializeField] int playerIndex;
    [SerializeField] GameObject readyGameObject;
    [SerializeField] PlayerVisual playerVisual;
    private void Start()
    {
        TestingGameManager.Instance.OnPlayerDataNetworkListChanged += GameManager_OnPlayerDataNetworkListChanged;
        CharacterSelectReady.Instance.OnReadyChanged += CharacterSelectReady_OnReadyChanged;
        //UpdatePlayer();
    }

    private void CharacterSelectReady_OnReadyChanged(object sender, System.EventArgs e)
    {
        UpdatePlayer();
    }

    private void GameManager_OnPlayerDataNetworkListChanged(object sender, System.EventArgs e)
    {
        UpdatePlayer();
    }

    private void UpdatePlayer()
    {
        if(TestingGameManager.Instance.IsPlayerIndexConnected(playerIndex)) 
        {
            Show();
            PlayerData playerData = TestingGameManager.Instance.GetPlayerDataFromIndex(playerIndex);
            readyGameObject.SetActive(CharacterSelectReady.Instance.IsPlayerReady(playerData.clientId));

            
            //changes to creator
            //playerVisual.SetPlayerColor(TestingGameManager.Instance.GetPlayerColor(playerData.colorId));
            //playerVisual.SetPlayerColor(TestingGameManager.Instance.GetPlayerColor(playerIndex));



            //Set the playervisual from instace testinggmaemanagers thrue index
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
