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
            SceneManager.LoadScene(nextScene);
        }

    }

    public IEnumerator scene()
    {
        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 0);
    
        // Wait until the first canvas has been destroyed
        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
    
        // Instantiate the next canvas here
        cutsceneCanvas = Instantiate(dialogueCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 0);

        // Wait until the second canvas has been destroyed
        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 1);

        while (cutsceneCanvas != null)
        {
            yield return null; // Wait for the next frame
        }

        yield return new WaitForSeconds(1.0f); // Wait for 1 second
        cutsceneCanvas = Instantiate(fadeOutCanvasPrefab);
        SceneManager.LoadScene(nextScene);
    }

}

