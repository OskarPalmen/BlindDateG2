using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject guessButton;
    private ClickableImageToggle untoggledCharacter;
    public GameObject correctPopUp;
    public GameObject wrongPopUp;

    private bool guessMode = false;

    private void Start()
    {
        ClickableImageToggle[] characterToggles = FindObjectsOfType<ClickableImageToggle>();
        guessButton.SetActive(false);
    }

    public bool IsGuessMode => guessMode;

    public void ToggleGuessMode()
    {
        guessMode = !guessMode;
        Debug.Log("Guess Mode: " + (guessMode ? "On" : "Off"));
    }

    public void CharacterClicked(ClickableImageToggle characterToggle)
    {
        if (guessMode)
        {
            untoggledCharacter = characterToggle;
            MakeGuess();
        }
        else
        {
            characterToggle.ToggleImageVisibility();
            UpdateGuessButton();
        }
    }

    public void UpdateGuessButton()
    {
        ClickableImageToggle[] characterToggles = FindObjectsOfType<ClickableImageToggle>();
        int untoggledCharacterCount = 0;
        foreach (ClickableImageToggle toggle in characterToggles)
        {
            if (!toggle.IsChecked)
            {
                untoggledCharacterCount++;
                untoggledCharacter = toggle;
            }
        }
        guessButton.SetActive(untoggledCharacterCount == 1);
    }

    public void MakeGuess()
    {
        if (untoggledCharacter != null)
        {
            string untoggledCharacterTag = untoggledCharacter.gameObject.tag;
            Debug.Log("Untoggled Character Tag: " + untoggledCharacterTag);

            if (untoggledCharacterTag == "PlayerCharacter")
            {
                Debug.Log("You guessed the player character! You Win");

                correctPopUp.SetActive(true);
                wrongPopUp.SetActive(false);
                correctPopUp.transform.SetAsLastSibling();
                wrongPopUp.transform.SetAsLastSibling();
            }
            else if (untoggledCharacterTag == "NPCCharacter")
            {
                Debug.Log("You guessed an NPC character! You lose LOL");
                correctPopUp.SetActive(false);
                wrongPopUp.SetActive(true);
                correctPopUp.transform.SetAsLastSibling();
                wrongPopUp.transform.SetAsLastSibling();
            }
            else
            {
                Debug.Log("Unknown character tag: " + untoggledCharacterTag);
            }
        }
        else
        {
            Debug.Log("No untoggled character found.");
        }
    }
}