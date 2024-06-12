using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motherEvent : eventManager
{
    [SerializeField] public GameObject WOMANprefab;
    [SerializeField] public Transform[] WOMANpoints;

    private npcMovement npcMovement; // Add this line

    public override void onEvent()
    {
        eventName = "motherEvent";
        GameObject Woman = Object.Instantiate(WOMANprefab);
        Woman.name = "WOMAN";

        npcMovement = Woman.GetComponent<npcMovement>();
        npcMovement.points = WOMANpoints;

        StartCoroutine(WaitForDialogues());
    }

    private IEnumerator WaitForDialogues()
    {
        yield return new WaitUntil(() => npcMovement.routineDone);

        narratorCanvas = Object.Instantiate(descriptionCanvasPrefab);
        narratorCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 1);
    }
}

