using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomizeAllButton : MonoBehaviour
{
    public void OnRandomizeButtonClicked()
    {
        HatUICustomizationPart[] customizationPartsHat = FindObjectsOfType<HatUICustomizationPart>();
        EyesUICustomizationPart[] customizationPartsEyes = FindObjectsOfType<EyesUICustomizationPart>();
        MouthUICustomizationPart[] customizationPartsMouth = FindObjectsOfType<MouthUICustomizationPart>();

        foreach (HatUICustomizationPart part in customizationPartsHat)
        {
            part.ApplyRandomCustomization();
        }

        foreach (EyesUICustomizationPart part in customizationPartsEyes)
        {
            part.ApplyRandomCustomization();
        }

        foreach (MouthUICustomizationPart part in customizationPartsMouth)
        {
            part.ApplyRandomCustomization();
        }

    }
}
