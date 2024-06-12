/*
cardAnimationManager.cs

This script is responsible for managing the animations of the cards in the trading card game. 
It includes a public float variable for the duration of the card animation. 
When the game object this script is attached to is instantiated, it starts a coroutine that waits for the duration of the card animation and then destroys the game object. 
This is used to play a one-time animation such as a card being played or discarded, and then remove the animation from the game.

Luis Filorio and Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardAnimationManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip effectSound;
    [SerializeField] public float cardAnimationTime = 1.0f;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = stateNameController.volume;
        audioSource.clip = effectSound;
        StartCoroutine(playAndDestroy());
    }

    IEnumerator playAndDestroy()
    {
        audioSource.Play();
        yield return new WaitForSeconds(cardAnimationTime);
        Destroy(gameObject);
    }
}