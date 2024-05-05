using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideableObject : MonoBehaviour
{
    private Collider2D objectCollider;

    public void Start()
    {
        objectCollider = GetComponent<Collider2D>();
    }
}
