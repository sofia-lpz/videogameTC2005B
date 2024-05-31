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

    private bool loginSuccess = false;

    void Start()
    {
        loginButton.onClick.AddListener(onLoginButtonClicked);
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
        
        if (tcgData.playerStatus == "OK")
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