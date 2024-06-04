/*
introManager.cs

This script is responsible for managing cutscenes
It controls the flow of the cutscene by instantiating different types of canvases (dialogue, cutscene, fade out) 
and initializing them with appropriate parameters. 
The cutscene progresses based on user input (pressing the 'S' key to skip) or when the current canvas is destroyed. 
Once the cutscene is over, it adds the cutscene to the list of played cutscenes and loads the next scene.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutsceneManager : MonoBehaviour
{
    [SerializeField] public GameObject dialogueCanvasPrefab;
    [SerializeField] public GameObject CutsceneCanvasPrefab;
    [SerializeField] public GameObject fadeOutCanvasPrefab;
    [SerializeField] public string nextScene = "Outside";
    protected GameObject cutsceneCanvas;
    protected string cutsceneName;

    public virtual void Start()
    {
        cutsceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(scene());
    }

    
    public virtual void Update()
    {
        if (stateNameController.gamePaused){
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StopAllCoroutines();
            cutsceneCanvas = Instantiate(fadeOutCanvasPrefab);
            stateNameController.freezePlayer = false;
            stateNameController.playedCutscenes.Add(cutsceneName);
            SceneManager.LoadScene(nextScene);
        }

    }

    public virtual IEnumerator waitUntilCanvasDestroyed()
    {
        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
    }

    public virtual IEnumerator scene()
    {
        Debug.Log("Cutscene: " + cutsceneName);
        yield return null;
    }

}

