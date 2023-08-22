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
    private bool guessMode = false;

    private void Start()
    {
        canvasTransform = FindObjectOfType<Canvas>().transform;
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
    }

    private void CancelGuess()
    {
        Destroy(currentConfirmationMenu); // Destroy the confirmation menu
        currentConfirmationMenu = null;
        ToggleGuessMode();
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