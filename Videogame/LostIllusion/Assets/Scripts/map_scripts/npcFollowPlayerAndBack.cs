using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcFollowPlayerAndBack : Character_Movement
{
    [SerializeField] public Transform[] points;
    public int pointsIndex = 0;
    public bool routineDone = false;
    Vector2 originalPosition;

    public override void Start()
    {
        base.Start();
        originalPosition = transform.position;
        
    }

    public override void Update()
    {
        if (stateNameController.gamePaused || stateNameController.freezePlayer)
        {
            animator.SetBool("Moving", false);
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            forceTalk forceTalkComponent = GetComponent<forceTalk>();
            if (forceTalkComponent != null && forceTalkComponent.talkedTo)
            {
                // If forceTalk.TalkedTo is true, walk back to the original position
                transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
                Vector2 direction = (originalPosition - (Vector2)transform.position).normalized;
                animator.SetFloat("X", direction.x);
                animator.SetFloat("Y", direction.y);

                // If the NPC has arrived back at its original position, set Moving to false
                if ((Vector2)transform.position == originalPosition)
                {
                    animator.SetBool("Moving", false);
                    routineDone = true;
                }
                else
                {
                    animator.SetBool("Moving", true);
                }
            }
            else
            {
                // If forceTalk.TalkedTo is false, move towards the player
                Vector2 targetPosition = player.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
                animator.SetFloat("X", direction.x);
                animator.SetFloat("Y", direction.y);
                animator.SetBool("Moving", true);
            }
        }
        else
        {
            Debug.LogError("Player GameObject not found");
        }
    }
    }

