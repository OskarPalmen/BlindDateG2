using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreatCharacterMenu : MonoBehaviour
{
    public GameObject character;
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

    //public void Submit()
    //{
    //    PrefabUtility.SaveAsPrefabAsset(character, "Assets/Prefab/Player.prefab");
    //}
}
