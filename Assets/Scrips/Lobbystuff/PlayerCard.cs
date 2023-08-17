using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] private CharacterDatabase characterDatabase;
    [SerializeField] private GameObject visuals;
    [SerializeField] private Image charactericonImage;
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private TMP_Text characterNameText;


    public void UpdateDisplay(CharacterSelectState state)
    {
        if(state.CharacterId != -1)
        {
            var character = characterDatabase.GetCharacterById(state.CharacterId);
            charactericonImage.sprite = character.Icon;
            charactericonImage.enabled = true;
            characterNameText.text = character.DisplayName;

        }
        else
        {
            charactericonImage.enabled = false;
        }

        playerNameText.text = $"Player {state.ClientId}";

        visuals.SetActive(true);
    }

    public void DisableDisplay()
    {
        visuals.SetActive(false);
    }
}
