using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtons : MonoBehaviour
{
    void login()
    {
        SceneManager.LoadScene("login", LoadSceneMode.Single);
    }

    void register()
    {
        SceneManager.LoadScene("register", LoadSceneMode.Single);
    }  
}
