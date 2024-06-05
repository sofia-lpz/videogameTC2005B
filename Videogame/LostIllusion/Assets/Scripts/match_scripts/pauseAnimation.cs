using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseAnimation : MonoBehaviour
{
    public void Pause()
    {
        GetComponent<Animator>().speed = 0;
    }
    void Update()
    {
        if (stateNameController.gamePaused)
        {
            GetComponent<Animator>().speed = 0;
        }
        else
        {
            GetComponent<Animator>().speed = 1;
        }  
    }
}
