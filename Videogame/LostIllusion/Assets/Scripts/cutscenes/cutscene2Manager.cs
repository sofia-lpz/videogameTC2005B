using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscene2Manager : MonoBehaviour
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
        stateNameController.playedCutscenes.Add("cutscene2");
            SceneManager.LoadScene(nextScene);
        }

    }

    public IEnumerator scene()
    {
        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 3);
    
        // Wait until the first canvas has been destroyed
        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second


        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(dialogueCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 2);

        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 5);

        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(dialogueCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 3);

        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(fadeOutCanvasPrefab);
        stateNameController.playedCutscenes.Add("cutscene2");
        SceneManager.LoadScene(nextScene);
    }

}

