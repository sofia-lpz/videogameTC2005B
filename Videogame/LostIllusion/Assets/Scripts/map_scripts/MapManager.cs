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
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvasPrefab;
    [SerializeField] GameObject CutsceneCanvasPrefab;

    void Start()
    {
        
    if (stateNameController.playerPreviousScene != "")
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(stateNameController.playerXPosInScene, stateNameController.playerYPosInScene, 0);
    }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !stateNameController.gamePaused)
        {
            GameObject pauseCanvas = Object.Instantiate(PauseCanvasPrefab);
            stateNameController.gamePaused = true;
        }
    }

    public void StartCutscene(string cutsceneName)
    {
        StartCoroutine(StartCutsceneAndWait(cutsceneName));
    }

    public IEnumerator StartCutsceneAndWait(string cutsceneName)
    {
        Debug.Log("MapManager started coruitine");
        GameObject cutsceneCanvas = Object.Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("cutsceneStart", 0);
        yield return new WaitForSeconds(2);
        Destroy(cutsceneCanvas);
        Debug.Log("Starting cutscene: " + cutsceneName);
        SceneManager.LoadScene(cutsceneName); 
    }


}
