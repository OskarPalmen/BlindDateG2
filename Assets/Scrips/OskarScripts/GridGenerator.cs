using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject npcPrefab;         // Prefab for the normal NPCs
    public GameObject enemyNpcPrefab;    // Prefab for the enemy NPC
    public int rows = 3;                 // Number of rows in the grid
    public int columns = 3;              // Number of columns in the grid

    public float horizontalSpacing = 100.0f; // Spacing between NPCs horizontally
    public float verticalSpacing = 100.0f;   // Spacing between NPCs vertically

    public RectTransform panel; // Reference to the Panel component

    void Start()
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
                    prefabToSpawn = enemyNpcPrefab;
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