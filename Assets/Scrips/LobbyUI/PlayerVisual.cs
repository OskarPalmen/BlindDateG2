using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVisual : MonoBehaviour
{
    // add stuff to make the visual for the character

    ////[SerializeField] private MeshRenderer hatMeshRenderer;
    ////[SerializeField] private MeshRenderer hairMeshRenderer;
    ////[SerializeField] private MeshRenderer faceMeshRenderer;
    ////[SerializeField] private MeshRenderer mouthMeshRenderer;


    //[Header("Image To Change")]
    //[SerializeField] private Image hatImage;
    //[SerializeField] private Image hairImage;
    //[SerializeField] private Image eyeImage;
    //[SerializeField] private Image noseImage;
    //[SerializeField] private Image mouthImage;
    //[SerializeField] private Image bodyImage;

    //[Header("Sprites To Cycle Through")]
    //[SerializeField] private List<Sprite> options = new List<Sprite>();

    //[Header("Colors")]
    //[SerializeField] private List<Color> colors = new List<Color>();



    //private int currentOption = 0;
    //private int whatColor = 1;

    //private Material material;

    private void Awake()
    {
        //hatImage.GetComponent<Image>();


        //material = new Material(hatMeshRenderer.material);
        //hatMeshRenderer.material = material;
        //hairMeshRenderer.material = material;
        //faceMeshRenderer.material = material;
        //mouthMeshRenderer.material = material;
    }

    public void SetPlayerColor(Color color)
    {
        //material.color = color;
    }

    private void Update()
    {
        //for (int i = 0; i < colors.Count; i++)
        //{
        //    if (i == whatColor)
        //    {
        //        hatImage.color = colors[i];
        //    }
        //}
    }



    //public void RightImage()
    //{
    //    currentOption++;
    //    if (currentOption >= options.Count)
    //    {
    //        currentOption = 0; // Reset if cycled through the entire list
    //    }
    //    hatImage.sprite = options[currentOption];
    //}

    //public void LeftImage()
    //{
    //    currentOption--;
    //    if (currentOption <= 0)
    //    {
    //        currentOption = options.Count - 1; // Reset if cycled through the entire list
    //    }
    //    hatImage.sprite = options[currentOption];
    //}

    //public void Randomize()
    //{
    //    currentOption = Random.Range(0, options.Count - 1);
    //    hatImage.sprite = options[currentOption];
    //}

    //public void ColorChanger(int index)
    //{
    //    whatColor = index;
    //}

    //public void ColorRandomize()
    //{
    //    whatColor = Random.Range(0, colors.Count - 1);
    //    hatImage.color = colors[whatColor];
    //}

}
