using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningEvent : eventManager
{
    [SerializeField] public GameObject FRIENDprefab;
    [SerializeField] public Transform[] FRIENDpoints;

    private npcMovement npcMovement; // Add this line

    public override void onEvent()
    {
        eventName = "runningEvent";
        GameObject Kel = Object.Instantiate(FRIENDprefab);
        Kel.name = "ADRIAN";

        npcMovement = Kel.GetComponent<npcMovement>();
        npcMovement.points = FRIENDpoints;

        StartCoroutine(WaitForDialogues());
    }

    private IEnumerator WaitForDialogues()
    {
        yield return new WaitUntil(() => npcMovement.routineDone);

        narratorCanvas = Object.Instantiate(descriptionCanvasPrefab);
        narratorCanvas.GetComponent<dialogue>().Initialize("COLOMETA", 1);
    }
}
