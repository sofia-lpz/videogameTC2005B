using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkToMe : triggerableObject
{
    [SerializeField] public bool interacted = false;
    [SerializeField] public GameObject prefabDialogueCanvas;
    [SerializeField] public int dialogueIndex = 1;
    
    public override void onTriggerEnter(GameObject other)
    {
        
        base.onTriggerEnter(other);

        if (other.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Return)){
                onTalk();
            }
        }
    }

    void onTalk()
    {
        GameObject dialogueCanvas = Object.Instantiate(prefabDialogueCanvas);
        dialogueCanvas.GetComponent<dialogue>().Initialize(gameObject.name, dialogueIndex);
    }
}
