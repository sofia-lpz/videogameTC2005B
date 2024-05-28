using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardAnimationManager : MonoBehaviour
{
    [SerializeField] public float cardAnimationTime = 1.0f;

    void Start()
    {
        StartCoroutine(playAndDestroy());
    }

    IEnumerator playAndDestroy()
    {
        yield return new WaitForSeconds(cardAnimationTime);
        Destroy(gameObject);
    }
}