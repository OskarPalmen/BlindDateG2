using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject character;
    [SerializeField] private string nextScene;
    public List<OutfitChanger> outfitChangers = new List<OutfitChanger>();
    public List<ColorTintScript> colourTintScript = new List<ColorTintScript>();
    public void RandomizeCharacter()
    {
        foreach (OutfitChanger changer in outfitChangers)
        {
            changer.Randomize();
        }
        foreach (ColorTintScript changer in colourTintScript)
        {
            changer.ColorRandomize();
        }
    }

    public void Submit()
    {
        SceneManager.LoadScene(nextScene);
    }
}
