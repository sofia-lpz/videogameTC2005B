/*
forceFight.cs

This script is responsible for managing the forced fight interactions
It extends the triggerableObject class and overrides the onTriggerEnter method to handle interactions with the player. 
When the player enters the trigger area, the script checks if a fight has already occurred. 
If not, it initiates a fight by freezing the player, saving the player's position, and loading the fight scene. 
If a fight has already occurred, it initiates a dialogue with the player. 
The script also includes a coroutine to wait until the dialogue is finished before loading the fight scene.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class forceFight : triggerableObject
{
    [SerializeField] public bool interacted = false;
    [SerializeField] public GameObject prefabDialogueCanvas;
    string sceneNameFight;
    int dialogueIndex = 0;
    
    public override void onTriggerEnter(GameObject other)
    {
        
        base.onTriggerEnter(other);

        sceneNameFight = "match_" + gameObject.name;

        if (other.tag == "Player" && !interacted){
                var fieldInfo = typeof(stateNameController).GetField(sceneNameFight);
                int fieldValue = (int)fieldInfo.GetValue(null);

                if (fieldValue == 0)
                {
                    onFight(other);
                }
                else
                {
                    onTalkAfter(fieldValue);
                    interacted = true;
                }
        }
    }

void onFight(GameObject other)
{
    if (!interacted)
    {
        interacted = true;
        stateNameController.freezePlayer = true;
        stateNameController.playerXPosInScene = other.transform.position.x;
        stateNameController.playerYPosInScene = other.transform.position.y;
        stateNameController.playerPreviousScene = SceneManager.GetActiveScene().name;
        
        //GameObject dialogueCanvas = Object.Instantiate(prefabDialogueCanvas);
        
        var fieldInfo = typeof(stateNameController).GetField(sceneNameFight);
        
        int fieldValue = (int)fieldInfo.GetValue(null);
        dialogueIndex = fieldValue;
        
        //dialogueCanvas.GetComponent<dialogue>().Initialize(gameObject.name, dialogueIndex);

        UnityEngine.SceneManagement.SceneManager.LoadScene("match_CENTIPEDE");
    }
}

void onTalkAfter(int fieldValue)
    {
        GameObject dialogueCanvas = Object.Instantiate(prefabDialogueCanvas);
        
        if (fieldValue == 1)
        {
            dialogueCanvas.GetComponent<dialogue>().Initialize(gameObject.name, 1);
        }
        else
        {
            dialogueCanvas.GetComponent<dialogue>().Initialize(gameObject.name, 2);
        }
    }
}