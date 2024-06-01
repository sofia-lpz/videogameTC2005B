/*
talkToMe.cs

This script is responsible for managing the dialogue interactions with NPCs in the game. 
It extends the triggerableObject class and overrides the onTriggerEnter method to handle interactions with the player. 
When the player enters the trigger area and presses the Return key, the script initiates a dialogue by instantiating a dialogue canvas and initializing it with the name of the game object and the index of the dialogue.

Sofia Moreno
*/
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
