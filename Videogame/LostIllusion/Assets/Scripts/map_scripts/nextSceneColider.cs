/*
Script to change the scene when the player enters a trigger zone
Map

Sofia Moreno
4/5/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    [SerializeField] public string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
