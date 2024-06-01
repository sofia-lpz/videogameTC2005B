/*
triggerableObject.cs

This script is responsible for managing the triggerable objects in the game. 
It uses a 2D collider to detect when the player enters or exits the trigger area of the game object. 
When the player is in the trigger area, the onTriggerEnter method is called every frame. 
The onTriggerEnter method is virtual and can be overridden by subclasses to handle different types of interactions with the player.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerableObject : MonoBehaviour
{
    [SerializeField] public Collider2D objectCollider;
    private bool playerInTrigger = false;
    private GameObject player;

    public virtual void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        if (objectCollider != null)
        {
            objectCollider.isTrigger = true; // Ensure the collider is set as a trigger
        }
    }

    public virtual void Update()
    {
        if (playerInTrigger)
        {
            onTriggerEnter(player);
        }
    }

    public virtual void onTriggerEnter(GameObject other)
    {
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInTrigger = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInTrigger = false;
            player = null;
        }
    }
}