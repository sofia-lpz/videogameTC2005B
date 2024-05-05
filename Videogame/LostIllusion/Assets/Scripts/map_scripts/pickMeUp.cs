using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickMeUp : collideableObject
{
    
    public override void onCollision(GameObject other)
    {
        base.onCollision(other);
        if (other.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.E)){
                onPickUp(other);
            }
        }
    }

    void onPickUp(GameObject other)
    {
        Debug.Log("Picked up: " + other.name);
        Destroy(gameObject);
    }
}
