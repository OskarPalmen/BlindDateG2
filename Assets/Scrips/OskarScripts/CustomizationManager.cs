using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    public List<Sprite> hatSprites = new List<Sprite>();
    public List<Sprite> eyesSprites = new List<Sprite>();
    public List<Sprite> mouthSprites = new List<Sprite>();

    public static CustomizationManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
