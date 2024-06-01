/*
tutorialManager.cs

This script is responsible for managing the tutorial.
It controls the flow of the tutorial by playing a click sound and fading in a "skip" text when the space key is pressed. 
The tutorial can be skipped by pressing the space key, which triggers a fade-out effect and then loads the specified scene. 
The script also adjusts the volume of the audio source to match the current volume setting in the game.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class tutorialManager : MonoBehaviour
{
    [SerializeField] public string sceneName;
    [SerializeField] public TextMeshProUGUI skipText;
    AudioSource audioSource;
    [SerializeField] public AudioClip clickSound;
    [SerializeField] public GameObject fadeOutCanvasPrefab;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clickSound;
        audioSource.volume = stateNameController.volume;
        StartCoroutine(FadeText());
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            audioSource.Play();
            StartCoroutine(waitalittle());
        }
        
    }

    IEnumerator FadeText()
    {
        yield return new WaitForSeconds(3.0f); // Wait for 1 second
        for (float t = 0.01f; t < 1; t += 0.01f)
        {
            // Adjust the alpha value of the text
            skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, Mathf.Lerp(0, 1, t));
            yield return null;
        }
    }

    IEnumerator waitalittle()
    {
        GameObject fadeOutCanvas = Instantiate(fadeOutCanvasPrefab);
        yield return new WaitForSeconds(2.0f); // Wait for 1 second
        
        SceneManager.LoadScene(sceneName);
    }
}
