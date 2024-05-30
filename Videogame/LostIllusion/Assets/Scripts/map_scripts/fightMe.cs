/*
Script to start a match in the map
to use, simply attach to enemy

Sofia Moreno
4/5/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fightMe : collideableObject
{
    [SerializeField] public bool interacted = false;
    [SerializeField] public GameObject prefabDialogueCanvas;
    int dialogueIndex = 0;
    string sceneNameFight;
    
    public override void onCollision(GameObject other)
    {
        sceneNameFight = "match_" + gameObject.name;

        base.onCollision(other);
        if (other.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Return)){
                var fieldInfo = typeof(stateNameController).GetField(sceneNameFight);
                int fieldValue = (int)fieldInfo.GetValue(null);

                if (fieldValue == 0)
                {
                    onFight(other);
                }
                else
                {
                    onTalkAfter(fieldValue);
                }

            }
        }
    }

void onFight(GameObject other)
{
    
    if (!interacted)
    {
        interacted = true;
        stateNameController.freezePlayer = true;
        stateNameController.playerPosInScene = other.transform.position.x;
        stateNameController.playerPreviousScene = SceneManager.GetActiveScene().name;
        
        GameObject dialogueCanvas = Object.Instantiate(prefabDialogueCanvas);
        
        var fieldInfo = typeof(stateNameController).GetField(sceneNameFight);
        
            int fieldValue = (int)fieldInfo.GetValue(null);
            dialogueIndex = fieldValue;
        

        dialogueCanvas.GetComponent<dialogue>().Initialize(gameObject.name, dialogueIndex);

        StartCoroutine(WaitAndLoadScene(sceneNameFight, dialogueCanvas));
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

IEnumerator WaitAndLoadScene(string sceneName, GameObject dialogueCanvas)
{
    // Wait until the dialogue canvas is destroyed
    while (dialogueCanvas != null)
    {
        yield return null; // Wait for next frame
    }

    yield return new WaitForSeconds(1.0f); // Wait for 1 second

    // Load the scene
    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
}
}