using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : Character_Movement
{
    [SerializeField] private Transform[] points;
    private int pointsIndex = 0;
    private float moveSpeed = 5f;

    public override void Update()
    {
        if (stateNameController.gamePaused)
        {
            animator.SetBool("Moving", false);
            return;
        }
        
        if (pointsIndex < points.Length)
        {
            Vector2 targetPosition = points[pointsIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPosition) < 0.001f)
            {
                pointsIndex++;
            }
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

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
}
