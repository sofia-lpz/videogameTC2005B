using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkToMe : collideableObject
{
    [SerializeField] public bool interacted = false;
    [SerializeField] public GameObject prefabDialogueCanvas;
    
    public override void onCollision(GameObject other)
    {
        base.onCollision(other);
        if (other.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Return)){
                onTalk(other);
            }
        }
    }

    void onTalk(GameObject other)
    {
        GameObject dialogueCanvas = Object.Instantiate(prefabDialogueCanvas);
    }
}
