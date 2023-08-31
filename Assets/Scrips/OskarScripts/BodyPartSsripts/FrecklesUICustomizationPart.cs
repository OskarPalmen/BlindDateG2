using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrecklesUICustomizationPart : MonoBehaviour
{
    public Sprite[] customizationSprites; // Existing sprites
    public GameObject playerPrefab; // Reference to the player prefab
    public string customizationPartName; // Name of the customization part (e.g., "Hat", "Eyes", "Mouth")

    private Image imageComponent;
    private bool characterSelectPlayerReady = false;
    private void Awake()
    {
        imageComponent = GetComponentInChildren<Image>();
        //ApplyRandomCustomization();
    }

    private void Start()
    {
        StartCoroutine(WaitForCharacterSelectPlayer());
    }


    private IEnumerator WaitForCharacterSelectPlayer()
    {
        while (!characterSelectPlayerReady)
        {
            GameObject characterSelectPlayer = GameObject.FindGameObjectWithTag("PlayerCharacter");
            if (characterSelectPlayer != null)
            {
                playerPrefab = characterSelectPlayer;
                characterSelectPlayerReady = true;
            }
            yield return null;
        }

        ApplyRandomCustomization();
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
