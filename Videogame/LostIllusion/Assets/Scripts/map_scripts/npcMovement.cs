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
            if (HasParameter("Moving"))
            {
                animator.SetBool("Moving", false);
            }
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
                    routineDone = true;
                    Destroy(gameObject);
                    return;
                }
                pointsIndex++;
            }
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            if (HasParameter("X"))
            {
                animator.SetFloat("X", direction.x);
            }
            if (HasParameter("Y"))
            {
                animator.SetFloat("Y", direction.y);
            }
            if (HasParameter("Moving"))
            {
                animator.SetBool("Moving", true);
            }
        }
        else
        {
            if (HasParameter("Moving"))
            {
                animator.SetBool("Moving", false);
            }
            routineDone = true;
        }
    }

    private bool HasParameter(string paramName)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName) return true;
        }
        return false;
    }
    }

