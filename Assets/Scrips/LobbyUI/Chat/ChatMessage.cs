using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;

    public void SetMessage(string playerName, string message)
    {
        textField.text = $"<color=green>{playerName}</color>: {message}";
    }
}
