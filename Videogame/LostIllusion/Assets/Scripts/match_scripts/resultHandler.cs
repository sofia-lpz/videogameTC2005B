/*
resultHandler.cs

This script is responsible for handling the results of matches in the game. 
It includes two public static methods, match_lost and match_won, which are called when a match is lost or won, respectively. 
Both methods get the name of the active scene, which is used as the field name in the stateNameController class. 
If the field exists, its value is set to -1 for a lost match or 1 for a won match. 
If the field does not exist, an error message is logged.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resultHandler : MonoBehaviour
{


    public static void match_lost()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        var fieldInfo = typeof(stateNameController).GetField(sceneName);
        if (fieldInfo != null)
        {
            fieldInfo.SetValue(null, -1);
            
            Debug.Log("Match lost and logged");
        }
        else
        {
            Debug.LogError("Field " + sceneName + " does not exist in stateNameController");
        }
    }

 public static void match_won()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        var fieldInfo = typeof(stateNameController).GetField(sceneName);
        if (fieldInfo != null)
        {
            fieldInfo.SetValue(null, 1);
            Debug.Log(stateNameController.match_tv);
            Debug.Log("Match won and logged");
        }
        else
        {
            Debug.LogError("Field " + sceneName + " does not exist in stateNameController");
        }
    }
}


