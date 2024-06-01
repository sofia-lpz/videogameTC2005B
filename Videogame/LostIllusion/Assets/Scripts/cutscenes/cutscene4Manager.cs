/*
cutscene4Manager.cs

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

public class cutscene4Manager : MonoBehaviour
{
    [SerializeField] public GameObject dialogueCanvasPrefab;
    [SerializeField] public GameObject CutsceneCanvasPrefab;
    [SerializeField] public GameObject fadeOutCanvasPrefab;
    [SerializeField] public string nextScene = "Outside";
    private GameObject cutsceneCanvas; // Declare cutsceneCanvas here
    private int introIndex = 0;

    void Start()
    {
        StartCoroutine(scene());
    }

    // Update is called once per frame
    void Update()
    {
        if (stateNameController.gamePaused){
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            cutsceneCanvas = Instantiate(fadeOutCanvasPrefab);
        stateNameController.playedCutscenes.Add("cutscene4");
            SceneManager.LoadScene(nextScene);
        }

    }

    public IEnumerator scene()
    {
        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 8);
    
        // Wait until the first canvas has been destroyed
        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second


        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(dialogueCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 6);

        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 9);

        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(dialogueCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 7);

        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 10);

        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(dialogueCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 8);

        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 11);

        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(fadeOutCanvasPrefab);
        stateNameController.playedCutscenes.Add("cutscene4");
        SceneManager.LoadScene(nextScene);
    }

}

