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
        inventory_temp.inventory.Add(gameObject.name);
        Debug.Log("Picked up: " + inventory_temp.inventory[inventory_temp.inventory.Count - 1]);
        Destroy(gameObject);
        }
    }
}
