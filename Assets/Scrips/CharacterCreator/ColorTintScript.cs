using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTintScript : MonoBehaviour
{
    [Header("Color To Change")]
    public SpriteRenderer coloredBodyPart;

    [Header("Colors To Cycle Through")]
    public List<Color> tintColors = new List<Color>();

    private int currentOption = 0;

    public void NextColor()
    {
        currentOption++;
        if(currentOption >= tintColors.Count)
        {
            currentOption = 0; // Reset if cycled through the entire list
        }
        coloredBodyPart.color = tintColors[currentOption];
    }
    public void PreviousColor()
    {
        currentOption--;
        if (currentOption <= 0)
        {
            currentOption = tintColors.Count - 1; // Reset if cycled through the entire list
        }
        coloredBodyPart.color = tintColors[currentOption];
    }
    public void ColorRandomize()
    {
        currentOption = Random.Range(0, tintColors.Count - 1);
        coloredBodyPart.color = tintColors[currentOption];
    }
}
