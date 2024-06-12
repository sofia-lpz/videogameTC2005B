/*
Script to pick up objects in the game
to use, simply attach to object you want to make pickable

Sofia Moreno
4/5/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickMeUp : collideableObject
{
    public bool interacted = false;
    [SerializeField] public GameObject prefabDescriptionCanvas;
    [SerializeField] public GameObject prefabPickedObject;
    [SerializeField] public string cutsceneName;
    
    public override void onCollision(GameObject other)
    {
        base.onCollision(other);
        if (other.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Return)){
                onPickUp();
            }
        }
    }

    public virtual void onPickUp()
    {
        if (!interacted){
        interacted = true;
        GameObject pickedObject = Object.Instantiate(prefabPickedObject, transform.position, Quaternion.identity);

        stateNameController.inventory.Add(gameObject.name);
        Debug.Log("Picked up: " + stateNameController.inventory[stateNameController.inventory.Count - 1]);

        
        
        }
    }

}
