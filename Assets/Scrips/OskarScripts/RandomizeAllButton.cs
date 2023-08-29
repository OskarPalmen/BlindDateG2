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
        FacialHairUICustomizationPart[] customizationPartFacialHair = FindObjectsOfType<FacialHairUICustomizationPart>();
        HairUICustomizationPart[] customizationPartHair = FindObjectsOfType<HairUICustomizationPart>();
        FrecklesUICustomizationPart[] customizationPartFreckles = FindObjectsOfType<FrecklesUICustomizationPart>();

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

        foreach (FacialHairUICustomizationPart part in customizationPartFacialHair)
        {
            part.ApplyRandomCustomization();
        }

        foreach (HairUICustomizationPart part in customizationPartHair)
        {
            part.ApplyRandomCustomization();
        }

        foreach (FrecklesUICustomizationPart part in customizationPartFreckles)
        {
            part.ApplyRandomCustomization();
        }


    }
}
