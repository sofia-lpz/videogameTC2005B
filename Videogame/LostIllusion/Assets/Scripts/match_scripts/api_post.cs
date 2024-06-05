using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class api_post : MonoBehaviour
{

//para llamarlo cuando se acabe la match de acuerdo al tcg_controller
    public void postData(string username, string password)
    {
        StartCoroutine(PostAuthData(username, password));
    }


//post de ejemplo, es para hacer registro
IEnumerator PostAuthData(string username, string password)
    {
        using (UnityWebRequest www = UnityWebRequest.PostWwwForm("http://localhost:3000/api/register/" + username + "/" + password, ""))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Request failed: " + www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                Debug.Log("Request successful: " + result);
            }
        }
    }
}
