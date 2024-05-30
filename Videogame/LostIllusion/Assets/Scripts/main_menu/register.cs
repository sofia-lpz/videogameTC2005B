using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

        if (username == "" || password == "")
        {
            registerMessageText.text = "Empty field";
            yield return null;
        }
        else if (true) // if username already doesnt exist
        {
            registerMessageText.text = "Registro exitoso";
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("mainMenu");
        }
        else
        {
            registerMessageText.text = "Usuario y existe";
            yield return null;
        }
    }
}
