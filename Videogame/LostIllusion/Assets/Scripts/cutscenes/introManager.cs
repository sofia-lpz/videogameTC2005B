using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introManager : MonoBehaviour
{
    [SerializeField] public GameObject dialogueCanvasPrefab;
    [SerializeField] public GameObject CutsceneCanvasPrefab;

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
        
    }

    IEnumerator scene(){
        GameObject cutsceneCanvas = Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize("NARRATOR", 0);

        yield return new WaitForSeconds(1);

        GameObject dialogueCanvas = Instantiate(dialogueCanvasPrefab);
        dialogueCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 0);
    }
}
