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
    
    public override void onCollision(GameObject other)
    {
        base.onCollision(other);
        if (other.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Return)){
                onPickUp(other);
            }
        }
    }

    void onPickUp(GameObject other)
    {
        if (!interacted){
        interacted = true;
        GameObject descriptionCanvas = Object.Instantiate(prefabDescriptionCanvas);

        stateNameController.inventory.Add(gameObject.name);
        Debug.Log("Picked up: " + stateNameController.inventory[stateNameController.inventory.Count - 1]);
        Destroy(gameObject);
        }
    }
}
