using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : Character_Movement
{
    [SerializeField] public Transform[] points;
    public int pointsIndex = 0;
    public bool routineDone = false;

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
                // If the point is named "destroy", destroy the GameObject
                if (points[pointsIndex].name == "destroy")
                {
                    Destroy(gameObject);
                    return;
                }
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
            routineDone = true;
        }
    }
    }

