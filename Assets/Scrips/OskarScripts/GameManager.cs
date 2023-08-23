using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Transform canvasTransform;
    public GameObject guessButton;
    private ClickableImageToggle untoggledCharacter;
    public GameObject correctPopUp;
    public GameObject wrongPopUp;
    public GameObject confirmationMenuPrefab;
    private GameObject currentConfirmationMenu;
    public GameObject askButton;
    private bool guessMode = false;
    private int currentPlayerTurn = 0; // 0 represents Player 1, 1 represents Player 2


    private void Start()
    {
        canvasTransform = FindObjectOfType<Canvas>().transform;
        ClickableImageToggle[] characterToggles = FindObjectsOfType<ClickableImageToggle>();
        guessButton.SetActive(false);
    }

    public bool IsGuessMode => guessMode;
    public int CurrentPlayerTurn => currentPlayerTurn;

    public void ToggleGuessMode()
    {
        guessMode = !guessMode;
        Debug.Log("Guess Mode: " + (guessMode ? "On" : "Off"));
    }


    public void EndTurn()
    {
        currentPlayerTurn = (currentPlayerTurn + 1) % 2; // Switch turns between 0 and 1
        Debug.Log("Turn ended for Player " + (currentPlayerTurn + 1));
        // Enable or disable the AskButton based on the current player's turn
        //askButton.SetActive(currentPlayerTurn == NetworkManager.LocalPlayerId);
    }


    public void CharacterClicked(ClickableImageToggle characterToggle)
    {
        if (IsGuessMode)
        {
            currentConfirmationMenu = Instantiate(confirmationMenuPrefab);
            currentConfirmationMenu.transform.SetParent(canvasTransform, false);
            // You might need to set the position and customize the appearance of the menu here.

            // Attach the appropriate callbacks to the Yes and No buttons.
            Button yesButton = currentConfirmationMenu.transform.Find("YesButton").GetComponent<Button>();
            Button noButton = currentConfirmationMenu.transform.Find("NoButton").GetComponent<Button>();

            yesButton.onClick.AddListener(() => ConfirmGuess(characterToggle));
            noButton.onClick.AddListener(CancelGuess);
        }
        else
        {
            characterToggle.ToggleImageVisibility();
            UpdateGuessButton();
        }
    }

    private void ConfirmGuess(ClickableImageToggle characterToggle)
    {
        Destroy(currentConfirmationMenu); // Destroy the confirmation menu
        currentConfirmationMenu = null;

        untoggledCharacter = characterToggle;
        MakeGuess();
        // Exit GuessMode after making a guess
        ToggleGuessMode();
        EndTurn();
    }

    private void CancelGuess()
    {
        Destroy(currentConfirmationMenu); // Destroy the confirmation menu
        currentConfirmationMenu = null;
        ToggleGuessMode();
    }


    // Add a method to check if it's the current player's turn
    //public bool IsCurrentPlayerTurn()
    //{
    //    return currentPlayerTurn == NetworkManager.LocalPlayerId; // Replace with actual logic for identifying local player
    //}


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