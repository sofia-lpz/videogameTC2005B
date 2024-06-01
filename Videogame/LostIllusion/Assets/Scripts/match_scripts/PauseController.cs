/*
PauseController.cs

This script is responsible for managing the pause functionality in the game. 
It listens for the 'P' key press during the game. 
When the 'P' key is pressed, it checks if the game is not already paused. 
If the game is not paused, it instantiates the PauseCanvasPrefab and sets the gamePaused state to true, effectively pausing the game.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvasPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !stateNameController.gamePaused)
        {
            GameObject pauseCanvas = Object.Instantiate(PauseCanvasPrefab);
            stateNameController.gamePaused = true;
        
        }

    }
}
