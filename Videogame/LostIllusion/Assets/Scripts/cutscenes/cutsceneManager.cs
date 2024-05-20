using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneManager : MonoBehaviour
{

    [SerializeField] public GameObject dialogueCanvasPrefab;
    

    void Start()
    {
        GameObject dialogueCanvas = Object.Instantiate(dialogueCanvasPrefab);
        dialogueCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 0);

    }
    
    void Update()
    {
        if (stateNameController.gamePaused){
            return;
        }
        
    }
}
