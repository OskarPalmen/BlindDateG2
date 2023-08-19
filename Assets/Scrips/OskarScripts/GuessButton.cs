using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessButton : MonoBehaviour
{
    public GameObject correctPopUp;
    public GameObject wrongPopUp;

    public void OnGuessButtonClicked()
    {
        // Here you would determine if the guess is correct or wrong.
        bool isGuessCorrect = DetermineGuess(); // Implement this method.

        if (isGuessCorrect)
        {
            correctPopUp.SetActive(true);
            wrongPopUp.SetActive(false);
        }
        else
        {
            correctPopUp.SetActive(false);
            wrongPopUp.SetActive(true);
        }
    }

    private bool DetermineGuess()
    {
        // Implement your logic to determine if the guess is correct.
        // This might involve comparing the guessed character with the actual character.
        // Return true if correct, false if wrong.
        return true; // Replace with actual implementation.
    }
}