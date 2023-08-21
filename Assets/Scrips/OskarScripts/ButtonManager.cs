using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button randomizeButton;
    public HatUICustomizationPart[] customizationParts;

    private void Start()
    {
        randomizeButton.onClick.AddListener(RandomizeAllCustomization);
    }

    public void RandomizeAllCustomization()
    {
        foreach (HatUICustomizationPart part in customizationParts)
        {
            part.ApplyRandomCustomization();
        }
    }
}