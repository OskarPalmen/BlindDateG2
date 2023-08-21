using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesUICustomizationPart : MonoBehaviour
{
    public Sprite[] customizationSprites; // Existing sprites
    public GameObject playerPrefab; // Reference to the player prefab
    public string customizationPartName; // Name of the customization part (e.g., "Hat", "Eyes", "Mouth")

    private Image imageComponent;

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
        //ApplyRandomCustomization();
    }

    public void ApplyRandomCustomization()
    {
        List<Sprite> allSprites = new List<Sprite>(customizationSprites);

        Transform customizationPart = playerPrefab.transform.Find(customizationPartName);

        if (customizationPart != null)
        {
            Image[] imageComponents = customizationPart.GetComponentsInChildren<Image>();

            foreach (Image img in imageComponents)
            {
                allSprites.Add(img.sprite);
            }
        }

        if (allSprites.Count > 0)
        {
            int randomIndex = Random.Range(0, allSprites.Count);
            Sprite randomSprite = allSprites[randomIndex];

            imageComponent.sprite = randomSprite;
        }
    }
}