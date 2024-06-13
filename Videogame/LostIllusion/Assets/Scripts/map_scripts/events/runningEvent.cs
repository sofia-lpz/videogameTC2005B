using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningEvent : eventManager
{
    private npcMovement npcMovement; // Add this line
    GameObject Adrian;

    public override void onEvent()
    {
        eventName = "runningEvent";

        if (stateNameController.triggeredEvents.Contains(eventName))
        {
            Adrian = GameObject.Find("ADRIAN");
            Destroy(Adrian);
            return;
        }

        stateNameController.triggeredEvents.Add(eventName);
        Adrian = GameObject.Find("ADRIAN");
        npcMovement = Adrian.GetComponent<npcMovement>();
        npcMovement.enabled = true;

        StartCoroutine(WaitForDialogues());
    }

    private IEnumerator WaitForDialogues()
    {
        yield return new WaitUntil(() => npcMovement.routineDone);
        narratorCanvas = Object.Instantiate(descriptionCanvasPrefab);
        narratorCanvas.GetComponent<dialogue>().Initialize("runningEvent", 0);

        yield return new WaitUntil(() => narratorCanvas == null);

        bool containsCutscene2 = stateNameController.playedCutscenes.Contains("cutscene2");
        bool containsCutscene3 = stateNameController.playedCutscenes.Contains("cutscene3");
        bool containsCutscene4 = stateNameController.playedCutscenes.Contains("cutscene4");

        narratorCanvas = Object.Instantiate(descriptionCanvasPrefab);
        if (containsCutscene2 && containsCutscene3 && containsCutscene4)
        {
            Debug.Log("All cutscenes played");
            narratorCanvas.GetComponent<dialogue>().Initialize("runningEvent", 2);
        }
        else
        {
            Debug.Log("Not all cutscenes played");
            narratorCanvas.GetComponent<dialogue>().Initialize("runningEvent", 1);
        }
    }
}

