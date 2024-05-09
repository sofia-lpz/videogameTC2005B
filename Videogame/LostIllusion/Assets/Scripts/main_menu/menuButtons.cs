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

    public void resume()
    {
        stateNameController.gamePaused = false;
        Destroy(transform.parent.gameObject);
    }

    public void quit()
    {
        SceneManager.LoadScene("MainTitle", LoadSceneMode.Single);
    }
}
