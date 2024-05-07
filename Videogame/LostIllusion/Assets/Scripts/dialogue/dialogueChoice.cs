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
