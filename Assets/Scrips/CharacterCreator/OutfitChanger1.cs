using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitChanger1 : MonoBehaviour
{
    [Header("Sprite To Change")]
    public SpriteRenderer bodyPart;
    
    [Header("Sprites To Cycle Through")]
    public List<Sprite> options = new List<Sprite>();

    private int currentOption = 0;

    public void NextOption()
    {
        currentOption++;
        if(currentOption >= options.Count)
        {
            currentOption = 0; // Reset if cycled through the entire list
        }
        bodyPart.sprite = options[currentOption];
    }

    public void PreviousOption()
    {
        currentOption--;
        if (currentOption <= 0)
        {
            currentOption = options.Count - 1; // Reset if cycled through the entire list
        }
        bodyPart.sprite = options[currentOption];
    }

    public void Randomize()
    {
        currentOption = Random.Range(0, options.Count - 1);
        bodyPart.sprite = options[currentOption];
    }
}
