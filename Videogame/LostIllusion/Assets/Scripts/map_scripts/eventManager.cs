using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : triggerableObject
{
    // woman asks for help
    // strange man tells you about the pica
    //friends run to you

    protected string eventName;
    [SerializeField] public GameObject descriptionCanvasPrefab;
    protected GameObject narratorCanvas;

    public override void onTriggerEnter(GameObject other)
    {
        base.onTriggerEnter(other);

        if (other.tag == "Player" && !stateNameController.triggeredEvents.Contains(eventName))
        {
            onEvent();
            stateNameController.triggeredEvents.Add(eventName);
        }
    }

    public virtual void onEvent(){

    }
}
