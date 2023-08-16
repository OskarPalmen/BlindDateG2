using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject guessButton;
    private int uncheckedCharacterCount = 0;

    private void Start()
    {
        // Find all the ClickableImageToggle components in the scene
        ClickableImageToggle[] characterToggles = FindObjectsOfType<ClickableImageToggle>();
        uncheckedCharacterCount = characterToggles.Length;

        // Hide the guess button initially
        guessButton.SetActive(false);
    }

    public void CharacterToggled(bool isChecked)
    {
        if (isChecked)
        {
            // Reduce the count of unchecked characters when a character is clicked
            uncheckedCharacterCount--;

            // Check if there's only one character left unchecked
            if (uncheckedCharacterCount == 1)
            {
                guessButton.SetActive(true);
            }
            else if (uncheckedCharacterCount == 0)
            {
                guessButton.SetActive(false);
            }
        }
        else
        {
            // Increase the count of unchecked characters when a character is unchecked
            uncheckedCharacterCount++;

            // Hide the guess button when unchecking starts
            guessButton.SetActive(false);
        }
    }
}