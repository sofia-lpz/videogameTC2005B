using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motherEvent : eventManager
{
    private npcMovement npcMovement; // Add this line

    public override void onEvent()
    {
        eventName = "motherEvent";
        GameObject Woman = GameObject.Find("WOMAN");
        if (Woman != null)
        {
            npcMovement = Woman.GetComponent<npcMovement>();
            if (npcMovement != null)
            {
                npcMovement.enabled = true;
            }
            else
            {
                Debug.LogError("npcMovement component not found on WOMAN GameObject");
            }
        }
        else
        {
            Debug.LogError("WOMAN GameObject not found");
        }

        StartCoroutine(WaitForDialogues());
    }

    private IEnumerator WaitForDialogues()
    {
        yield return new WaitUntil(() => npcMovement.routineDone);

        narratorCanvas = Object.Instantiate(descriptionCanvasPrefab);
        narratorCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 1);
    }
}

