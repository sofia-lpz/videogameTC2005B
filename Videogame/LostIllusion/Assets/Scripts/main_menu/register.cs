using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class register : MonoBehaviour
{
    [SerializeField] public TMP_InputField usernameField;
    [SerializeField] public TMP_InputField passwordField;
    [SerializeField] public Button registerButton;
    [SerializeField] public TMP_Text registerMessageText;

    void Start()
    {
        registerButton.onClick.AddListener(onRegisterButtonClicked);
    }

    void onRegisterButtonClicked()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            registerMessageText.text = "Empty field";
            yield return null;
        }
        else
        {
            yield return StartCoroutine(PostAuthData(username, password));
        }
    }

    IEnumerator PostAuthData(string username, string password)
    {
        using (UnityWebRequest www = UnityWebRequest.PostWwwForm("http://localhost:3000/api/register/" + username + "/" + password, ""))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Request failed: " + www.error);
                registerMessageText.text = "User already exists";
            }
            else
            {
                string result = www.downloadHandler.text;
                Debug.Log("Request successful: " + result);
                registerMessageText.text = "Registro exitoso";
                yield return new WaitForSeconds(1);
                SceneManager.LoadScene("mainMenu");
            }
        }
    }
}
