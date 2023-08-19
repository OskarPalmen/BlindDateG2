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

    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>(); // Reference to the Canvas component

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

                // Calculate the position for the new NPC in canvas space
                Vector3 canvasPosition = new Vector3(startX + col * horizontalSpacing, startY + row * verticalSpacing, 0);

                // Convert the canvas position to world space
                Vector3 worldPosition = canvas.transform.TransformPoint(canvasPosition);

                // Instantiate the NPC prefab at the calculated position
                GameObject newNPC = Instantiate(prefabToSpawn, worldPosition, Quaternion.identity);

                // Set the Canvas as the parent of the newly instantiated NPC
                newNPC.transform.SetParent(canvas.transform);
            }
        }
    }
}