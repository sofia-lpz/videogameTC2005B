/*
forceTalk.cs

This script is responsible for managing the forced dialogue interactions
It extends the triggerableObject class and overrides the onTriggerEnter method to handle interactions with the player. 
When the player enters the trigger area, the script checks if a dialogue has already occurred. 
If not, it initiates a dialogue by creating a dialogue canvas and initializing it with the name of the game object and the index of the dialogue. 
The script also includes a method for handling the dialogue interaction.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceTalk : triggerableObject
{
    [SerializeField] public bool interacted = false;
    [SerializeField] public GameObject prefabDialogueCanvas;
    public bool talkedTo = false;
    
    public override void onTriggerEnter(GameObject other)
    {
        
        base.onTriggerEnter(other);

        if (other.tag == "Player" && !interacted && !stateNameController.triggeredCharacters.Contains(gameObject.name)){
                onTalk();
                interacted = true;
                stateNameController.triggeredCharacters.Add(gameObject.name);
        }
    }

    void onTalk()
    {
        talkedTo = true;
        GameObject dialogueCanvas = Object.Instantiate(prefabDialogueCanvas);
        dialogueCanvas.GetComponent<dialogue>().Initialize(gameObject.name, 0);
    }
}
