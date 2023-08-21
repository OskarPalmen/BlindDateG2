using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject guessButton;

    private ClickableImageToggle untoggledCharacter; // Reference to the untoggled character
    public GameObject correctPopUp;
    public GameObject wrongPopUp;

    private void Start()
    {
        // Find all the ClickableImageToggle components in the scene
        ClickableImageToggle[] characterToggles = FindObjectsOfType<ClickableImageToggle>();

        // Hide the guess button initially
        guessButton.SetActive(false);
    }

    public void UpdateGuessButton()
    {
        // Find all the ClickableImageToggle components in the scene
        ClickableImageToggle[] characterToggles = FindObjectsOfType<ClickableImageToggle>();

        // Count the number of untoggled characters
        int untoggledCharacterCount = 0;
        foreach (ClickableImageToggle toggle in characterToggles)
        {
            if (!toggle.IsChecked)
            {
                untoggledCharacterCount++;
                untoggledCharacter = toggle; // Store the untoggled character reference
            }
        }

        // Show the guess button when there's only one untoggled character
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