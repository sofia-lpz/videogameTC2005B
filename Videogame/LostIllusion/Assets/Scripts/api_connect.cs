/*
api_connect.cs

This script is responsible for managing the API connections in the game. 
It sends GET requests to the specified API endpoints to retrieve data for cards and villagers. 
The data is processed by the api_processing class and stored in static variables for use in other parts of the game. 
The script also manages the interactability of the start, login, and register buttons, 
disabling them at the start of the game and enabling them once the data has been successfully retrieved.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System; // for Action<string>
using UnityEngine.UI;

public class api_connect : MonoBehaviour
{
    public static string result;
    public static string cardResults;
    public string url = "http://localhost:3000/api";
    [SerializeField] Button startButton;
    [SerializeField] Button loginButton;
    [SerializeField] Button registerButton;

    public void Start(){
        startButton.interactable = false; // disable the button
        loginButton.interactable = false; // disable the button
        registerButton.interactable = false; // disable the button
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
                startButton.interactable = true; // enable the button
                loginButton.interactable = true; // enable the button
            }
        }
    }
}