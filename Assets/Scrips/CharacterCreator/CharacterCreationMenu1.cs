using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CharacterCreationMenu1 : MonoBehaviour
{
    public GameObject character;
    //public List<OutfitChanger1> outfitChangers = new List<OutfitChanger1>();
    //public void RandomizeCharacter()
    //{
    //    foreach (OutfitChanger1 changer in outfitChangers)
    //    {
    //        changer.Randomize();
    //    }
    //}

    public void Submit()
    {
        PrefabUtility.SaveAsPrefabAsset(character, "Assets/Prefab/PlayerTestA.prefab");
    }
}
