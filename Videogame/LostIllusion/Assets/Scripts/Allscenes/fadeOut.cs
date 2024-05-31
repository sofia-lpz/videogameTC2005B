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