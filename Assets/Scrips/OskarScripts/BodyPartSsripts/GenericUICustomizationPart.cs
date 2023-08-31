using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericUICustomizationPart : MonoBehaviour
{
    public Sprite[] customizationSprites; // Existing sprites
    public GameObject playerPrefab; // Reference to the player prefab
    public string customizationPartName; // Name of the customization part (e.g., "Hat", "Eyes", "Mouth")

    private Image imageComponent;
    private bool characterSelectPlayerReady = false;

    public bool RandomizeOnStart = true;

    int lastIndex = 0;
    public int LastIndex => lastIndex;


    private void Awake()
    {
        imageComponent = GetComponentInChildren<Image>();
        //ApplyRandomCustomization();
    }

    private void Start()
    {
        if (RandomizeOnStart)
        {
            StartCoroutine(WaitForCharacterSelectPlayer());
        }
    }


    private IEnumerator WaitForCharacterSelectPlayer()
    {
        while (!characterSelectPlayerReady)
        {
            GameObject characterSelectPlayer = TestingPlayer.RemoteInstace.gameObject; //GameObject.FindGameObjectWithTag("PlayerCharacter");
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
            lastIndex = Random.Range(0, allSprites.Count);
            Sprite randomSprite = allSprites[lastIndex];

            imageComponent.sprite = randomSprite;
        }
    }
    
    public void SetCustomization(int i)
    {
        List<Sprite> allSprites = new(customizationSprites);

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
            int randomIndex = i; //Random.Range(0, allSprites.Count);
            Sprite randomSprite = allSprites[randomIndex];

            imageComponent.sprite = randomSprite;
        }
    }
}