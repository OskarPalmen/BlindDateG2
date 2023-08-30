using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorTintScript : MonoBehaviour
{
    //public Image bodyColor;

    public List<Color> colors = new List<Color>();

    public int whatColor = 1;


    public enum ColorTypePart
    {
        Skin,
        Hair,
        FacialHair,
        Eyes,
        Body,
    }
    public ColorTypePart Ctype;

    public void SetColor(Color color)
    {
        switch (Ctype)
        {
            case ColorTypePart.Hair:
                TestingPlayer.LocalInstace.hair.color = color;
                break;
            case ColorTypePart.FacialHair:
                TestingPlayer.LocalInstace.facialHair.color = color;
                break;
            case ColorTypePart.Eyes:
                TestingPlayer.LocalInstace.eyes.color = color;
                break;
            case ColorTypePart.Skin:
                TestingPlayer.LocalInstace.skin.color = color;
                break;
            case ColorTypePart.Body:
                TestingPlayer.LocalInstace.body.color = color;
                break;
        }
    }

    private void Awake()
    {
        //bodyColor.GetComponent<Image>();
    }

    public void ColorChanger (int index)
    {
        whatColor = index;
        for (int i = 0; i < colors.Count; i++)
        {
            if (i == whatColor)
            {
                //bodyColor.color = colors[i];
                SetColor(colors[i]);

            }
        }
    }

    public void ColorRandomize()
    {
        whatColor = Random.Range(0, colors.Count - 1);
        //bodyColor.color = colors[whatColor];
        SetColor(colors[whatColor]);
    }
}
