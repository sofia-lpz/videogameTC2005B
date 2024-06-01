/*
fadeOut.cs

This script is responsible for fading in an image
It uses a coroutine to gradually increase the alpha value of the image's color over a specified duration, 
creating a fade-in effect. The image is expected to be attached to the same GameObject as this script.

Sofia Moreno
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fadeOut : MonoBehaviour
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
        float startAlpha = image.color.a;
    
        for (float t = 0.01f; t < fadeDuration; t += Time.deltaTime)
        {
            // Adjust the alpha value of the image
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(startAlpha, 1, t / fadeDuration));
            yield return null;
        }
    
        // Ensure the image is fully opaque at the end
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    }
}