/*
menuButtons.cs

This script is responsible for managing the functionality of the menu buttons in the game. 
It includes methods for logging in, registering, starting the game, resuming the game, quitting the game, and debugging. 
Each method plays a click sound, changes the game state as necessary, and loads the appropriate scene. 
The script also includes a method for quitting the inventory, which unpauses the game and destroys the inventory game object.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuButtons : MonoBehaviour
{
    AudioSource audioSource;
    
    [SerializeField] public AudioClip clickSound;
    [SerializeField] public string nextSceneMenu;
    
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
        SceneManager.LoadScene(nextSceneMenu, LoadSceneMode.Single);
    }

    public void startDEV()
    {
        audioSource.Play();
        SceneManager.LoadScene("match_CENTIPEDE", LoadSceneMode.Single);
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
