using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : Character_Movement
{
    [SerializeField] private Transform[] points;
    private int pointsIndex = 0;

    public override void Update()
    {
        if (stateNameController.gamePaused || stateNameController.freezePlayer)
        {
            animator.SetBool("Moving", false);
            return;
        }
        
        if (pointsIndex < points.Length)
        {
            Vector2 targetPosition = points[pointsIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPosition) < 0.001f)
            {
                pointsIndex++;
            }
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            animator.SetFloat("X", direction.x);
            animator.SetFloat("Y", direction.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
    }

