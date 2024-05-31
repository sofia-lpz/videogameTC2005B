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
