using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundManager : MonoBehaviour
{
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    [SerializeField] AudioClip bgMusic;
    [SerializeField] AudioClip ambSound;

    void Start()
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
    void Update()
    {
        // Update the volume of both audio sources
        audioSource1.volume = stateNameController.volume;
        audioSource2.volume = stateNameController.volume;
    }
}