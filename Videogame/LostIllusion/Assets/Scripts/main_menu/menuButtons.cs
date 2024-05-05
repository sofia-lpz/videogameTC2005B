using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtons : MonoBehaviour
{
    public void login()
    {
        SceneManager.LoadScene("login", LoadSceneMode.Single);
    }

    public void register()
    {
        SceneManager.LoadScene("register", LoadSceneMode.Single);
    }  

    public void play()
    {
        string sceneName = stateNameController.scenes[stateNameController.player_level];
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
