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
