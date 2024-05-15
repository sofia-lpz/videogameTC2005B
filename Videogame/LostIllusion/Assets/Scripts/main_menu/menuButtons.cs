using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuButtons : MonoBehaviour
{
    AudioSource audioSource;
    
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Audio/soundEffects/cursor");
    }

    public void login()
    {
        audioSource.Play();
        SceneManager.LoadScene("login", LoadSceneMode.Single);
    }

    public void register()
    {
        audioSource.Play();
        SceneManager.LoadScene("register", LoadSceneMode.Single);
    }  

    public void play()
    {
        audioSource.Play();
        string sceneName = stateNameController.scenes[stateNameController.player_level];
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void resume()
    {
        audioSource.Play();
        stateNameController.gamePaused = false;
        Destroy(transform.parent.gameObject);
    }

    public void quit()
    {
        audioSource.Play();
        SceneManager.LoadScene("MainTitle", LoadSceneMode.Single);
    }

    public void quitInventory()
    {
        stateNameController.gamePaused = false;
        Destroy(transform.parent.gameObject);
    }

    public void debug()
    {
        Debug.Log("click!");
    }
}
