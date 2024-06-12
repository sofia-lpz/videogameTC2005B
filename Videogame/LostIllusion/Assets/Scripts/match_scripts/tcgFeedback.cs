using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tcgFeedback : MonoBehaviour
{
    [SerializeField] GameObject tcgFeedbackPrefab;
private GameObject currentFeedback;

public void ShowFeedback(string feedbackText)
{
    if (stateNameController.gamePaused)
        return;

    // Destroy the current feedback if it exists
    if (currentFeedback != null)
    {
        Destroy(currentFeedback);
    }

    currentFeedback = Instantiate(tcgFeedbackPrefab);
    currentFeedback.GetComponent<dialogue>().InitializeWithDialogue(feedbackText);
}

}
