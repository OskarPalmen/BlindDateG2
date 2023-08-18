using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomizeAllButton : MonoBehaviour
{
    public void OnRandomizeButtonClicked()
    {
        UICustomizationPart[] customizationParts = FindObjectsOfType<UICustomizationPart>();

        foreach (UICustomizationPart part in customizationParts)
        {
            part.ApplyRandomCustomization();
        }
    }
}
