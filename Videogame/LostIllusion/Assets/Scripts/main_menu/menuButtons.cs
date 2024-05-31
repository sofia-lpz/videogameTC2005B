using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuButtons : MonoBehaviour
{
    AudioSource audioSource;
    
    [SerializeField] public AudioClip clickSound;
    
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clickSound;

    }

    public void login()
    {
        audioSource.Play();
        SceneManager.LoadScene("login", LoadSceneMode.Single);
    }

    public void back()
    {
        audioSource.Play();
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }

    public void register()
    {
        audioSource.Play();
        SceneManager.LoadScene("register", LoadSceneMode.Single);
    }  

    public void startGame()
    {
        audioSource.Play();
        string sceneName = stateNameController.scenes[stateNameController.player_level];
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void startGameNOAUTH()
    {
        audioSource.Play();
        SceneManager.LoadScene("match_tv", LoadSceneMode.Single);
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
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
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

    public void mainMenu()
    {
        //audioSource.Play();
        SceneManager.LoadScene("Outside", LoadSceneMode.Single);
        
    }
}
