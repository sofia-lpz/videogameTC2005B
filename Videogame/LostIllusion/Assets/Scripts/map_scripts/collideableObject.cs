/*
collideableObject.cs

This script is responsible for managing the collision behavior of game objects
It uses a 2D collider to detect collisions with other game objects particularly made for the player
The script checks for collisions every frame and calls the onCollision method for each collided object. 
The onCollision method logs a message to the console indicating that a collision has occurred.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideableObject : MonoBehaviour
{
    [SerializeField] public Collider2D objectCollider;
    [SerializeField] public ContactFilter2D contactFilter;
    [SerializeField] public List<Collider2D> collidedObjects = new List<Collider2D>(1);


    public virtual void Start()
    {
        objectCollider = GetComponent<Collider2D>();
    }



    public virtual void Update()
{
    objectCollider.OverlapCollider(contactFilter, collidedObjects);
    foreach (var other in collidedObjects)
    {
        onCollision(other.gameObject);
    }
}

    public virtual void onCollision(GameObject other)
    {
        Debug.Log("Collision detected: " + gameObject.name);
    }
}