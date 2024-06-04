/*
Login.cs

This script is responsible for managing the login functionality of the game. 
It takes the user's input for username and password, validates the input, and sends a request to the server for authentication. 
If the username or password field is empty, it displays an error message. 
If the authentication is successful, it loads the main menu scene. 
If the authentication fails, it displays an error message.

Sofia Moreno
*/
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System; // for Action<string>

public class login : MonoBehaviour
{
    [SerializeField] public TMP_InputField usernameField;
    [SerializeField] public TMP_InputField passwordField;
    [SerializeField] public Button loginButton;
    [SerializeField] public TMP_Text loginMessageText;
    private string username;
    private string password;
    private string result;

    public static bool loginSuccess = false;

    void Start()
    {
        loginButton.onClick.AddListener(onLoginButtonClicked);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Return)){
            onLoginButtonClicked();
        }
    }

    void onLoginButtonClicked()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        username = usernameField.text;
        password = passwordField.text;
    
        if (username == "" || password == "")
        {
            loginMessageText.text = "Empty field";
            yield return null;
        }
        else
        {
            yield return GetAuthData(api_processing.PlayerProcessing);
    
            if (authentification()) // authentification success
            {
                loginMessageText.text = "Login exitoso";
                loginSuccess = true;
                yield return new WaitForSeconds(1);
                SceneManager.LoadScene("mainMenu");
            }
            else
            {
                loginMessageText.text = "Usuario o contraseña inválidos";
                yield return null;
            }
        }
    }

    bool authentification()
    {
        
        if (stateNameController.playerStatus == "OK")
        {
            Debug.Log("authentification success");
            return true;
        }
        else
        {
            Debug.Log("authentification failed");
            return false;
        }
    }

    IEnumerator GetAuthData(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:3000/api/auth/" + username + "/" + password))
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