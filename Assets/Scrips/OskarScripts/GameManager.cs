using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject guessButton;

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
            }
        }

        // Show the guess button when there's only one untoggled character
        guessButton.SetActive(untoggledCharacterCount == 1);
    }
}