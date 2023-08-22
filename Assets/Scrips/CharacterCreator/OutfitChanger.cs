using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutfitChanger : MonoBehaviour
{
    [Header("Image To Change")]
    public Image bodyPart;
    
    [Header("Sprites To Cycle Through")]
    public List<Sprite> options = new List<Sprite>();

    private int currentOption = 0;

    private void Awake ()
    {
        bodyPart.GetComponent<Image>();
    }

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
