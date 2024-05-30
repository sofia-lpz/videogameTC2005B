using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introManager : MonoBehaviour
{
    [SerializeField] public GameObject dialogueCanvasPrefab;
    [SerializeField] public GameObject CutsceneCanvasPrefab;
    private GameObject cutsceneCanvas; // Declare cutsceneCanvas here

    void Start()
    {
        cutsceneCanvas = Instantiate(dialogueCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogueCutscenes>().Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (stateNameController.gamePaused){
            return;
        }
        if (cutsceneCanvas == null || cutsceneCanvas.Equals(null))
        {
            Debug.Log("cutsceneCanvas has been destroyed");
        }
        else
        {
            Debug.Log("cutsceneCanvas still exists");
        }
    }
}