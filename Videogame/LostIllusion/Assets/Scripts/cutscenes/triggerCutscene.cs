/*
triggerCutscene.cs

This script is responsible for triggering a cutscene in a Unity game when the player enters a specific area. 
It inherits from the triggerableObject class and overrides its Start and onTriggerEnter methods. 
When the player enters the trigger area, the script saves the player's position and the current scene, 
then starts the cutscene.
The script also ensures that each cutscene can only be triggered once.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class triggerCutscene : pickMeUp
{
    [SerializeField] public GameObject CutsceneCanvasPrefab;

    public override void Start()
    {
        base.Start();
        if (stateNameController.playedCutscenes.Contains(cutsceneName)){
            Destroy(gameObject);
        }
    }

    public override void onPickUp()
    {
        base.onPickUp();
        GameObject other = GameObject.FindWithTag("Player");

        stateNameController.playerXPosInScene = other.transform.position.x;
        stateNameController.playerYPosInScene = other.transform.position.y;
        stateNameController.playerPreviousScene = SceneManager.GetActiveScene().name;

Debug.Log("Starting cutscene: " + cutsceneName);
        StartCoroutine(StartCutscene());
    }

    IEnumerator StartCutscene()
    {
        GameObject cutsceneCanvas = Object.Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize(gameObject.name, 0);
        yield return new WaitForSeconds(3);
        Destroy(cutsceneCanvas);
        SceneManager.LoadScene(cutsceneName); 
    }
}