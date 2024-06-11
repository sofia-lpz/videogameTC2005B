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
    [SerializeField] protected float speed;

    protected Rigidbody2D rb;
    protected Vector2 movement;
    protected Animator animator;

    
    [SerializeField] protected KeyCode up;
    [SerializeField] protected KeyCode down;
    [SerializeField] protected KeyCode left;
    [SerializeField] protected KeyCode right;
    protected string sceneName;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (stateNameController.scaryScenes.Contains(sceneName))
        {
            StartCoroutine(tremble());
        }
    }

    public virtual void Update()
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

    public virtual IEnumerator tremble()
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
