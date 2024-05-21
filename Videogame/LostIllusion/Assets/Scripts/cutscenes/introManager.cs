using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introManager : MonoBehaviour
{
    [SerializeField] public GameObject dialogueCanvasPrefab;
    [SerializeField] public GameObject CutsceneCanvasPrefab;

    void Start()
    {
        GameObject dialogueCanvas = Object.Instantiate(dialogueCanvasPrefab);
        dialogueCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 0);

        GameObject cutsceneCanvas = Object.Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (stateNameController.gamePaused){
            return;
        }
        
    }
}
