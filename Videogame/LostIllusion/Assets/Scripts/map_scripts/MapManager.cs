using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvasPrefab;
    [SerializeField] GameObject InventoryCanvasPrefab;

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
