using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorTintScript : MonoBehaviour
{
    public Image bodyColor;

    public List<Color> colors = new List<Color>();

    public int whatColor = 1;

    private void Awake ()
    {
        //bodyColor.GetComponent<Image>();
    }

    void Update ()
    {
        for (int i = 0; i < colors.Count; i++)
        {
            if (i == whatColor)
            {
                //bodyColor.color = colors[i];
            }
        }
    }

    public void ColorChanger (int index)
    {
        whatColor = index;
    }

    public void ColorRandomize()
    {
        whatColor = Random.Range(0, colors.Count - 1);
        bodyColor.color = colors[whatColor];
    }
}
