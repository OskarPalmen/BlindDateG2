using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor.PackageManager;
using UnityEngine;

public class GridGenerator : NetworkBehaviour
{
    public GameObject npcPrefab;         // Prefab for the normal NPCs
    public GameObject enemyNpcPrefab;    // Default prefab for the enemy NPC
    public GameObject playerNpcPrefab;    // Default prefab for the enemy NPC

    //public NetworkObject enemyNpcPrefab;    // Default prefab for the enemy NPC
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

            //GameObject characterSelectPlayer = GameObject.FindGameObjectWithTag("PlayerCharacter");
            GameObject characterSelectPlayer = TestingPlayer.LocalInstace.gameObject;
            GameObject characterSelectEnemy = TestingPlayer.RemoteInstace.gameObject;
            //NetworkObject characterSelectPlayer = (OwnerClientId == NetworkManager.Singleton.LocalClientId);

            //NetworkObject characterSelectPlayer = NetworkObject.FindObjectOfType<NetworkObject>(OwnerClientId == NetworkManager.Singleton.LocalClientId);
            //NetworkObject characterSelectPlayer = NetworkObject


            //GameObject characterSelectPlayer = gameObject.SetActive(OwnerClientId == NetworkManager.Singleton.LocalClientId);

            //if (OwnerClientId == 0)
            //{
            //    enemyNpcPrefab = characterSelectPlayer;
            //    characterSelectPlayerReady = true;
            //}
            //if (OwnerClientId == 1)
            //{
            //    enemyNpcPrefab = characterSelectPlayer;
            //    characterSelectPlayerReady = true;
            //}

            if (characterSelectPlayer != null)
            {
                enemyNpcPrefab = characterSelectEnemy;
                playerNpcPrefab = characterSelectPlayer;
                characterSelectPlayerReady = true;
            }
            yield return new WaitForEndOfFrame();
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
        int playerRow = Random.Range(0, rows);       // Random row for player
        int playerColumn = Random.Range(0, columns); // Random column for player
        while (enemyRow == playerRow && enemyColumn == playerColumn)
        {
            // re-randomize until enemy and player are on different tiles
            playerRow = Random.Range(0, rows);       
            playerColumn = Random.Range(0, columns);

        }


        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                GameObject prefabToSpawn = npcPrefab; // Default NPC prefab

                // Check if this is the location for the enemy NPC
                if (row == enemyRow && col == enemyColumn)
                {
                    prefabToSpawn = enemyNpcPrefab;
                    //enemyNpcPrefab = Instantiate(enemyNpcPrefab);
                    //foreach (var item in TestingPlayer.Instances)
                    //{

                    //    //TestingPlayer.Instances = Instantiate(prefabToSpawn, panelPosition, Quaternion.identity);
                    //    //item.transform.localPosition = new Vector3(0, 0, 0);
                    //    //item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    //}
                }
                else if(row == playerRow &&  col == playerColumn)
                {
                    prefabToSpawn = playerNpcPrefab;
                }

                // Calculate the position for the new NPC in panel space
                Vector3 panelPosition = new Vector3(startX + col * horizontalSpacing, startY + row * verticalSpacing, 0);

                //Instantiate the NPC prefab at the calculated position
                GameObject newNPC = Instantiate(prefabToSpawn, panelPosition, Quaternion.identity);
                //getting hiden childen from prefabs
                newNPC.transform.GetChild(0).gameObject.SetActive(true);
                // Set the Panel as the parent of the newly instantiated NPC
                newNPC.transform.SetParent(panel.transform, false); // Maintain local scale

                // If you want to maintain the world scale, use the following line:
                // newNPC.transform.SetParent(panel.transform);
            }
        }
    }

    //public void MoveCharater()
    //{
    //    // moving player prefab to y position after charatercreator screen
    //    foreach (var item in TestingPlayer.Instances)
    //    {
    //        item.transform.localPosition = new Vector3(0, 0, 0);
    //        item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    //    }
    //}
}
