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

public class cutscene4Manager : cutsceneManager
{
    
    public override IEnumerator scene()
    {
        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 8);
    
        yield return waitUntilCanvasDestroyed();

        cutsceneCanvas = Instantiate(dialogueCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 6);

        yield return waitUntilCanvasDestroyed();

        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 9);

        yield return waitUntilCanvasDestroyed();

        cutsceneCanvas = Instantiate(dialogueCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 7);

        yield return waitUntilCanvasDestroyed();

        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 10);

        yield return waitUntilCanvasDestroyed();

        cutsceneCanvas = Instantiate(dialogueCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 8);

        yield return waitUntilCanvasDestroyed();

        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 11);

        yield return waitUntilCanvasDestroyed();
        
        cutsceneCanvas = Instantiate(fadeOutCanvasPrefab);
        stateNameController.playedCutscenes.Add("cutscene4");
        SceneManager.LoadScene(nextScene);
    }

}

