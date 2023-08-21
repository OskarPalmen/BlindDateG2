using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CreatCharacterListObject : MonoBehaviour
{
    //[Header("Sprite To Change")]
    //public UnityEngine.UI.Image bodyPPart;
    ////public SpriteRenderer changeBody;

    //[Header("Sprites To Cycle Through")]
    //public List<UnityEngine.UI.Image> options = new List<UnityEngine.UI.Image>();

    //private int currentOption = 0;

    //public void NextOption()
    //{
    //    currentOption++;
    //    if (currentOption >= options.Count)
    //    {
    //        currentOption = 0; // Reset if cycled through the entire list
    //    }
    //    bodyPPart = options[currentOption];
    //}

    //public void PreviousOption()
    //{
    //    currentOption--;
    //    if (currentOption <= 0)
    //    {
    //        currentOption = options.Count - 1; // Reset if cycled through the entire list
    //    }
    //    bodyPPart = options[currentOption];
    //}

    //public void Randomize()
    //{
    //    currentOption = Random.Range(0, options.Count - 1);
    //    bodyPPart = options[currentOption];
    //}

    [Header("Sprite To Change")]
    public SpriteRenderer bodyPart;

    [Header("Sprites To Cycle Through")]
    public List<Sprite> options = new List<Sprite>();

    private int currentOption = 0;

    public void NextOption()
    {
        currentOption++;
        if (currentOption >= options.Count)
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

