/*
Sends the necessary information to the stateNameController
to update the player's level, inventory
and triggers correct dialogue

is for now a button

Sofia Moreno
5/5/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class map_won : MonoBehaviour
{
    public void match_won()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        var fieldInfo = typeof(stateNameController).GetField(sceneName);
        if (fieldInfo != null)
        {
            fieldInfo.SetValue(null, 1);
            Debug.Log(stateNameController.match_tv);
        }
        else
        {
            Debug.LogError("Field " + sceneName + " does not exist in stateNameController");
        }
    }

    public void buttonWin()
    {
        match_won();
    }
}


