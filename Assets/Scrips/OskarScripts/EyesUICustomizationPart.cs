using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesUICustomizationPart : MonoBehaviour
{
    public Sprite[] customizationSprites; // Or assign sprite references directly

    private Image imageComponent;

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
        //ApplyRandomCustomization();
    }

    public void ApplyRandomCustomization()
    {
        if (customizationSprites.Length > 0)
        {
            int randomIndex = Random.Range(0, customizationSprites.Length);
            Sprite randomSprite = customizationSprites[randomIndex];

            imageComponent.sprite = randomSprite;
        }
    }
}