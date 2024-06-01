/*
MapManager.cs

This script is responsible for managing the map in the game. 
It handles the instantiation of the Pause and Inventory canvases when the respective keys are pressed, and sets the game state to paused. 
It also contains commented-out code for setting the player's position based on saved state data when the scene starts, 
which will be used for scene transitions.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvasPrefab;
    [SerializeField] GameObject InventoryCanvasPrefab;
    [SerializeField] GameObject playerPrefab;

    void Start()
    {
        /*
        if (stateNameController.playerPreviousScene != "")
        {
            //find player by tag and change position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            
            player.transform.position = new Vector3(stateNameController.playerXPosInScene, stateNameController.playerYPosInScene, 0);
        }
        */
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !stateNameController.gamePaused)
        {
            GameObject pauseCanvas = Object.Instantiate(PauseCanvasPrefab);
            stateNameController.gamePaused = true;
        
        }

        if (Input.GetKeyDown(KeyCode.I) && !stateNameController.gamePaused)
        {
            GameObject inventoryCanvas = Object.Instantiate(InventoryCanvasPrefab);
            stateNameController.gamePaused = true;
        }

    }
}
