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
    public static string result;
    public static string cardResults;
    public string url = "http://localhost:3000/api";

    public void InitialGet(){
        GetData("/cards", cardResults);
    }

    public void GetData(string getEndpoint, string result){
        StartCoroutine(GetRequest(url + getEndpoint, result));
    }
IEnumerator GetRequest(string uri, string result)
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
