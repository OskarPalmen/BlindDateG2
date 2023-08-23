using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionDisplayText;

    public void OnQuestionButtonClicked(string question)
    {
        questionDisplayText.text = question;
    }
}