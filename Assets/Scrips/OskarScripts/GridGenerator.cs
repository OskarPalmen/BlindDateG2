using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor.PackageManager;
using UnityEngine;

public class GridGenerator : NetworkBehaviour
{
    public GameObject npcPrefab;         // Prefab for the normal NPCs
    public GameObject enemyNpcPrefab;    // Default prefab for the enemy NPC
    public int rows = 3;                 // Number of rows in the grid
    public int columns = 3;              // Number of columns in the grid

    public float horizontalSpacing = 100.0f; // Spacing between NPCs horizontally
    public float verticalSpacing = 100.0f;   // Spacing between NPCs vertically

    public RectTransform panel; // Reference to the Panel component

    private bool characterSelectPlayerReady = false;

    void Start()
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
                enemyNpcPrefab = characterSelectPlayer;
                characterSelectPlayerReady = true;
            }
            yield return null;
        }

        GenerateGrid();
    }

    private void GenerateGrid()
    {
        // Calculate the starting position based on the grid dimensions
        float startX = -(horizontalSpacing * (columns - 1)) / 2;
        float startY = -(verticalSpacing * (rows - 1)) / 2;

        int enemyRow = Random.Range(0, rows);       // Random row for enemy
        int enemyColumn = Random.Range(0, columns); // Random column for enemy

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                GameObject prefabToSpawn = npcPrefab; // Default NPC prefab

                // Check if this is the location for the enemy NPC
                if (row == enemyRow && col == enemyColumn)
                {
                    //prefabToSpawn = enemyNpcPrefab;
                    if (NetworkManager.Singleton.ConnectedClientsIds.Count >= 2)
                    {
                        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
                        {
                            //spawning in the player prefab
                            //enemyNpcPrefab = Instantiate(enemyNpcPrefab);
                            //enemyNpcPrefab.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId, true);
                        }
                    }

                }

                // Calculate the position for the new NPC in panel space
                Vector3 panelPosition = new Vector3(startX + col * horizontalSpacing, startY + row * verticalSpacing, 0);

                // Instantiate the NPC prefab at the calculated position
                GameObject newNPC = Instantiate(prefabToSpawn, panelPosition, Quaternion.identity);

                // Set the Panel as the parent of the newly instantiated NPC
                newNPC.transform.SetParent(panel.transform, false); // Maintain local scale

                // If you want to maintain the world scale, use the following line:
                // newNPC.transform.SetParent(panel.transform);
            }
        }
    }
}
