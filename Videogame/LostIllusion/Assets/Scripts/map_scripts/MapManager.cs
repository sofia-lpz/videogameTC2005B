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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player != null)
    {
        player.transform.position = new Vector3(stateNameController.playerXPosInScene, stateNameController.playerYPosInScene, 0);
    }
    else
    {
        Debug.Log("No GameObject found with the Player tag");
    }
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
