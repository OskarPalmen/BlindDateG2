using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OutfitChanger : NetworkBehaviour
{

    public enum BodyTypePart
    {
        Hair,
        FacialHair,
        Eyes,
        Mouth,
        Freckles,
        Hat,
        Accessories,

    }
    public BodyTypePart Btype;

    //[Header("Image To Change")]
    //public Image bodyPart;
    
    [Header("Sprites To Cycle Through")]
    public List<Sprite> options = new List<Sprite>();

    private int currentOption = 0;


    public void SetSprite(Sprite sprite)
    {
        switch (Btype)
        {
            case BodyTypePart.Hair:
                TestingPlayer.LocalInstace.hair.sprite = sprite;
                break;
            case BodyTypePart.FacialHair:
                TestingPlayer.LocalInstace.facialHair.sprite = sprite;
                break;
            case BodyTypePart.Eyes:
                TestingPlayer.LocalInstace.eyes.sprite = sprite;
                break;
            case BodyTypePart.Mouth:
                TestingPlayer.LocalInstace.mouth.sprite = sprite;
                break;
            case BodyTypePart.Freckles:
                TestingPlayer.LocalInstace.freckles.sprite = sprite;
                break;
            case BodyTypePart.Hat:
                TestingPlayer.LocalInstace.hat.sprite = sprite;
                break;
            case BodyTypePart.Accessories:
                TestingPlayer.LocalInstace.accessories.sprite = sprite;
                break;
        }
    }

    public void NextOption()
    {
       

        currentOption++;
        if(currentOption >= options.Count)
        {
            currentOption = 0; // Reset if cycled through the entire list
        }
        SetSprite(options[currentOption]);
    }

    public void PreviousOption()
    {
        currentOption--;
        if (currentOption <= 0)
        {
            currentOption = options.Count - 1; // Reset if cycled through the entire list
        }
        SetSprite(options[currentOption]);
    }

    public void Randomize()
    {
        currentOption = Random.Range(0, options.Count - 1);
        SetSprite(options[currentOption]);
    }
}
