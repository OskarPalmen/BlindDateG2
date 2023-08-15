using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationPart : MonoBehaviour
{
    public GameObject[] customizationPrefabs;

    private void Start()
    {
        ReplaceWithRandomPrefab();
    }

    public void ReplaceWithRandomPrefab()
    {
        if (customizationPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, customizationPrefabs.Length);
            GameObject randomPrefab = customizationPrefabs[randomIndex];

            Instantiate(randomPrefab, transform.position, transform.rotation);

            Destroy(gameObject); // Destroy the current customization part
        }
    }
}
