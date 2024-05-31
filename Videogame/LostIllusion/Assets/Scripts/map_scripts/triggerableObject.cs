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