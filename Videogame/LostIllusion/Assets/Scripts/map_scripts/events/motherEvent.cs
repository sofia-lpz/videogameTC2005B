using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motherEvent : eventManager
{
    private npcMovement npcMovement; // Add this line
    private npcFollowPlayerAndBack npcFollowPlayerAndBack; // Add this line

    
    public override void onEvent()
    {
        eventName = "motherEvent";

        if (stateNameController.triggeredEvents.Contains(eventName))
        {
            return;
        }

        stateNameController.triggeredEvents.Add(eventName);
        GameObject Woman = GameObject.Find("WOMAN");
        npcFollowPlayerAndBack = Woman.GetComponent<npcFollowPlayerAndBack>();

        stateNameController.triggeredEvents.Add(eventName);
        npcFollowPlayerAndBack.enabled = true;

        StartCoroutine(WaitForDialogues());
    }

    private IEnumerator WaitForDialogues()
    {
        yield return new WaitUntil(() => npcFollowPlayerAndBack.routineDone);

        narratorCanvas = Object.Instantiate(descriptionCanvasPrefab);
        narratorCanvas.GetComponent<dialogue>().Initialize("motherEvent", 0);
    }
}

