using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionButton : MonoBehaviour
{
    public string questionText; // Set this in the Inspector

    private void Start()
    {
        // Attach the button click listener
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Get the QuestionManager in the scene
        QuestionManager questionManager = FindObjectOfType<QuestionManager>();

        // Call the OnQuestionButtonClicked function with the question text
        questionManager.OnQuestionButtonClicked(questionText);
    }
}

