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
        CharacterSelectReady.Instance.OnReadyChanged += CharacterSelectReady_OnReadyChanged;
    }

    private void CharacterSelectReady_OnReadyChanged(object sender, System.EventArgs e)
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
