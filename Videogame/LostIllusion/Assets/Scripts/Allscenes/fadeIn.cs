/*
fadeIn.cs

This script is responsible for fading out an image
It uses a coroutine to gradually decrease the alpha value of the image's color over a specified duration, 
creating a fade-out effect for scene changes.
Once the fade-out is complete, the GameObject is destroyed so the scene can be clickable

Sofia Moreno
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fadeIn : MonoBehaviour
{
    public float fadeDuration = 1f; // The duration of the fade in seconds

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        for (float t = 0.01f; t < fadeDuration; t += Time.deltaTime)
        {
            // Adjust the alpha value of the image
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(1, 0, t / fadeDuration));
            yield return null;
        }
        Destroy(gameObject);
    }
}