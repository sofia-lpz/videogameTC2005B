/*
BgSoundManager.cs

This script is responsible for managing the background and ambient sounds
It creates two audio sources and assigns them audio clips for background music and ambient sound respectively. 
These audio sources are set to loop and play as soon as the game starts. 
In the Update method, the volume of these audio sources is updated to match the current volume setting in the game.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundManager : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    [SerializeField] public AudioClip bgMusic;
    [SerializeField] AudioClip ambSound;

    public void Start()
    {
        // Create two audio sources
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();

        // Set the clips and loop settings
        audioSource1.clip = bgMusic;
        audioSource1.loop = true;
        audioSource2.clip = ambSound;
        audioSource2.loop = true;

        // Play the audio sources
        audioSource1.Play();
        audioSource2.Play();
    }

    // Update is called once per frame
    public void Update()
    {
        // Update the volume of both audio sources
        audioSource1.volume = stateNameController.volume;
        audioSource2.volume = stateNameController.volume;
    }
}