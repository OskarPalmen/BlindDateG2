using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button randomizeButton;
    public UICustomizationPart[] customizationParts;

    private void Start()
    {
        randomizeButton.onClick.AddListener(RandomizeAllCustomization);
    }

    public void RandomizeAllCustomization()
    {
        foreach (UICustomizationPart part in customizationParts)
        {
            part.ApplyRandomCustomization();
        }
    }
}