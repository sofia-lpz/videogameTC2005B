/*
Handles requests

Sofia
14.5.24
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class api_connect : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getEndpoint;
    public static string result;

    public void Start()
    {
        GetData();
    }

    public void GetData(){
        StartCoroutine(GetRequest(url + getEndpoint));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(uri))
        {
            //make request and wait for response
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("request failed: " + www.error);
            }
            else
            {
                result = www.downloadHandler.text;
                Debug.Log("request successful: " + result);
            
            }
            
        }
    }
}
