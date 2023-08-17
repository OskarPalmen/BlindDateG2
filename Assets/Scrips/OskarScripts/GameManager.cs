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
        // Update the unchecked character count based on the toggle state
        uncheckedCharacterCount += isChecked ? -1 : 1;

        // Show or hide the guess button based on the unchecked character count
        guessButton.SetActive(uncheckedCharacterCount == 1);
    }
}