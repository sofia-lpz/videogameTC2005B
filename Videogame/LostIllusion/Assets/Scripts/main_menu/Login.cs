using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
    [SerializeField] public TMP_InputField usernameField;
    [SerializeField] public TMP_InputField passwordField;
    [SerializeField] public Button loginButton;
    [SerializeField] public TMP_Text loginMessageText;

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
        string username = usernameField.text;
        string password = passwordField.text;

        if (username == "" || password == "")
        {
            loginMessageText.text = "Empty field";
            yield return null;
        }
        else if (true) // authentification success
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