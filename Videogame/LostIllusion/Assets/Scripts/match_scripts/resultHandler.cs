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


