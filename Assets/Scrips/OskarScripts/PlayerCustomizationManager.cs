using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCustomizationData
{
    public Sprite hatSprite;
    public Sprite eyesSprite;
    public Sprite mouthSprite;
    // Add more body parts if needed
}

public class PlayerCustomizationManager : MonoBehaviour
{
    public PlayerCustomizationData playerCustomizationData;

    // Implement methods to set owned sprites
    public void SetHatSprite(Sprite sprite)
    {
        playerCustomizationData.hatSprite = sprite;
    }

    public void SetEyesSprite(Sprite sprite)
    {
        playerCustomizationData.eyesSprite = sprite;
    }

    public void SetMouthSprite(Sprite sprite)
    {
        playerCustomizationData.mouthSprite = sprite;
    }
}