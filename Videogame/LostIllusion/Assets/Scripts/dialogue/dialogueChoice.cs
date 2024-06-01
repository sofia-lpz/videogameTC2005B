/*
dialogueChoice.cs
UNUSED

This script is responsible for managing the dialogue choices 
It moves the position of the game object based on the player's input. 
If the player presses the down arrow key, the game object moves down, indicating a "no" choice. 
If the player presses the up arrow key, the game object moves back to its original position, indicating a "yes" choice.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueChoice : MonoBehaviour
{
    Vector3 position;

    void Start()
    {
        position = gameObject.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            no();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            yes();
        }
    }

    
    
   public void no()
{
    Vector3 noPosition = position;
    noPosition.y -= 37;
    gameObject.transform.position = noPosition;
}


public void yes()
{
    gameObject.transform.position = position;
}

}
