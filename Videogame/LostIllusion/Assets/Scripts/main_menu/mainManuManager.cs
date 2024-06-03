using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainManuManager : MonoBehaviour
{
    [SerializeField] public Button startButton;
    [SerializeField] public Button loginButton;
    [SerializeField] public Button registerButton;

    public void Start()
    {
        startButton.interactable = false; // disable the button
        loginButton.interactable = false; // disable the button
        registerButton.interactable = false; // disable the button
    }

    public void Update()
    {
        if (login.loginSuccess)
        {
            startButton.interactable = true; // enable the button
        }

        if (api_connect.apiConnected)
        {
            loginButton.interactable = true; // enable the button
            registerButton.interactable = true; // enable the button
        }

        if (login.loginSuccess && api_connect.apiConnected)
        {
            startButton.interactable = true; // enable the button
        }
    }   
}
