using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip bgMusic;
    [SerializeField] AudioClip ambSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgMusic;
        audioSource.loop = true;


        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = stateNameController.volume;
        

    }
}