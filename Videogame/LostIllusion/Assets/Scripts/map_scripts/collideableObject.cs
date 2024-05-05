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



    public void Update()
{

    objectCollider.OverlapCollider(contactFilter, collidedObjects);
    foreach (var obj in collidedObjects)
    {
        onCollision(obj.gameObject);
    }
}

    public void onCollision(GameObject other)
    {
        Debug.Log("Collision detected: " + other.name);
    }
}
