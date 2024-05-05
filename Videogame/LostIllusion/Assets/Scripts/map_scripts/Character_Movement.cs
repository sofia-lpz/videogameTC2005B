/*
Control the movements of the character

Luis Daniel Filorio Luna A01028418
10-04-2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    [SerializeField] float speed;

    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] GameObject DialogueCanvas;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("freezesPlayer") != null)
        {
            return; // If it's active, don't allow the player to move
        }

        movement.x = 0f;
        movement.y = 0f;

        if (Input.GetKey(up)){
            movement.y = 1f;
        } else if(Input.GetKey(down)){
            movement.y = -1f;
        } else if(Input.GetKey(left)){
            movement.x = -1f;
        } else if(Input.GetKey(right)){
            movement.x = 1f;
        } 

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}

