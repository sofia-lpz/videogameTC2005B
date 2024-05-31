using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceFight : triggerableObject
{
    [SerializeField] public bool interacted = false;
    [SerializeField] public GameObject prefabDialogueCanvas;
    
    public override void onTriggerEnter(GameObject other)
    {
        
        base.onTriggerEnter(other);

        if (other.tag == "Player" && !interacted){
                onTalk();
                interacted = true;
        }
    }

    void onTalk()
    {
        GameObject dialogueCanvas = Object.Instantiate(prefabDialogueCanvas);
        dialogueCanvas.GetComponent<dialogue>().Initialize(gameObject.name, 0);
    }
}
