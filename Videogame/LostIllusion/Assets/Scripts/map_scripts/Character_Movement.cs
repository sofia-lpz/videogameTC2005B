/*
Control the movements of the character

If there is an object called "freezesPlayer" in the scene, the player will not be able to move
5/5/2024

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
    private Animator animator;

    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] GameObject DialogueCanvas;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (stateNameController.gamePaused || stateNameController.freezePlayer)
        {
            animator.SetBool("Moving", false);
            return;
        }
        
        movement = Vector2.zero;

        if (Input.GetKey(up))
        {
            movement.y = 1f;
        }
        if (Input.GetKey(down))
        {
            movement.y = -1f;
        }
        if (Input.GetKey(left))
        {
            movement.x = -1f;
        }
        if (Input.GetKey(right))
        {
            movement.x = 1f;
        }

        // Normalize the movement vector to ensure consistent speed in all directions
        if (movement.sqrMagnitude > 1)
        {
            movement = movement.normalized;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(tremble());
        }

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    IEnumerator tremble()
    {
        float trembleAmount = 0.05f; // Adjust this value to change the intensity of the tremble
        float trembleSpeed = 60f; // Adjust this value to change the speed of the tremble

        Vector3 originalPosition = transform.position;

        float elapsedTime = 0f;

        while (elapsedTime < 0.75f) // Tremble for 1 second
        {
            float x = Mathf.Sin(Time.time * trembleSpeed) * trembleAmount;
            transform.position = new Vector3(originalPosition.x + x, originalPosition.y, originalPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset position
        transform.position = originalPosition;
    }
}
