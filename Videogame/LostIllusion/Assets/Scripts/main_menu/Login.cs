/* Login y Register - Avance 1 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoginRegister : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public Button loginButton;
    public TMP_Text loginMessageText;

    public TMP_InputField registerUsernameInput;
    public TMP_InputField registerPasswordInput;
    public Button registerButton;
    public TMP_Text registerMessageText;

    void Start()
    {
        if (loginButton != null)
        {
            loginButton.onClick.AddListener(onLoginButtonClicked);
        }

        if (registerButton != null)
        {
            registerButton.onClick.AddListener(onRegisterButtonClicked);
        }
    }

    void onLoginButtonClicked()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        userDatabase.User user = userDatabase.users.Find(u => u.username == username && u.password == password);
        if (user != null)
        {
            if (loginMessageText != null)
            {
                loginMessageText.text = "Login exitoso";
            }
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("mainMenu");
        }
        else
        {
            if (loginMessageText != null)
            {
                loginMessageText.text = "Usuario o contraseña inválidos";
            }
        }

        yield return null;
    }

    void onRegisterButtonClicked()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        string username = registerUsernameInput.text;
        string password = registerPasswordInput.text;

        if (userDatabase.users.Exists(u => u.username == username))
        {
            if (registerMessageText != null)
            {
                registerMessageText.text = "Este usuario ya existe";
            }
        }
        else
        {
            userDatabase.users.Add(new userDatabase.User { username = username, password = password });
            if (registerMessageText != null)
            {
                registerMessageText.text = "Registro exitoso";
            }
        }

        yield return null;
    }

    public static class userDatabase
    {
        public static List<User> users = new List<User>();

        public class User
        {
            public string username;
            public string password;
        }
    }
}



