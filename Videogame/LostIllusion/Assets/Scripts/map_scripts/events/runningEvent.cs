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
        narratorCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 1);
    }
}

