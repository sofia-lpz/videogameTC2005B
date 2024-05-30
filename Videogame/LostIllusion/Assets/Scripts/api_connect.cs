using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System; // for Action<string>

public class api_connect : MonoBehaviour
{
    public static string result;
    public static string cardResults;
    public string url = "http://localhost:3000/api";

    public void Start(){
        GetData("/cards", api_processing.CardProcessing);
        GetData("/villagers", api_processing.VillagerProcessing);
    }

    public void GetData(string getEndpoint, Action<string> callback){
        StartCoroutine(GetRequest(url + getEndpoint, callback));
    }   

    IEnumerator GetRequest(string uri, Action<string> callback)
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
                callback(result);
            }
        }
    }
}