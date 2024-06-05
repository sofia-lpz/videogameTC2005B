using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tcgFeedback : MonoBehaviour
{
    [SerializeField] GameObject tcgFeedbackPrefab;
    public static GameObject StaticTcgFeedbackPrefab;

    void Start()
    {
        StaticTcgFeedbackPrefab = tcgFeedbackPrefab;
    }
    
    public static void ShowFeedback(string feedbackText)
    {
        GameObject feedback = Instantiate(StaticTcgFeedbackPrefab);
        feedback.GetComponent<dialogue>().InitializeWithDialogue(feedbackText);
    }

}
