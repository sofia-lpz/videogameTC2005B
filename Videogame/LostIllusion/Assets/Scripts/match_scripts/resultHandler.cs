using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resultHandler : MonoBehaviour
{


    public void match_lost()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        var fieldInfo = typeof(stateNameController).GetField(sceneName);
        if (fieldInfo != null)
        {
            fieldInfo.SetValue(null, -1);
            
            Debug.Log("Match lost");
            StartCoroutine(WaitAndLoadScene());
        }
        else
        {
            Debug.LogError("Field " + sceneName + " does not exist in stateNameController");
        }
    }

 public void match_won()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        var fieldInfo = typeof(stateNameController).GetField(sceneName);
        if (fieldInfo != null)
        {
            fieldInfo.SetValue(null, 1);
            Debug.Log(stateNameController.match_tv);
            Debug.Log("Match won");
            StartCoroutine(WaitAndLoadScene());
        }
        else
        {
            Debug.LogError("Field " + sceneName + " does not exist in stateNameController");
        }
    }

    public IEnumerator WaitAndLoadScene()
    {
        Debug.Log("loading scene");
        yield return new WaitForSeconds(1.0f); // Wait for 1 second

        // Load the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }
}


