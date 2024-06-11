using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tcgFeedback : MonoBehaviour
{
    [SerializeField] GameObject tcgFeedbackPrefab;

    public void ShowFeedback(string feedbackText)
    {
        if (stateNameController.gamePaused)
            return;

        GameObject feedback = Instantiate(tcgFeedbackPrefab);
        feedback.GetComponent<dialogue>().InitializeWithDialogue(feedbackText);
    }

}
