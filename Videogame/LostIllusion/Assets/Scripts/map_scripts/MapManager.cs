using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvasPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !stateNameController.gamePaused)
        {
            GameObject pauseCanvas = Object.Instantiate(PauseCanvasPrefab);
        
        }
    }
}
