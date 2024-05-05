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
    
    public override void onCollision(GameObject other)
    {
        base.onCollision(other);
        if (other.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Return)){
                onFight(other);
            }
        }
    }

void onFight(GameObject other)
{
    string sceneName = "match_" + gameObject.name;
    if (!interacted)
    {
        interacted = true;
        GameObject dialogueCanvas = Object.Instantiate(prefabDialogueCanvas);
        StartCoroutine(WaitAndLoadScene(sceneName, dialogueCanvas));
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