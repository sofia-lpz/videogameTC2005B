using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneDialogue : dialogue
{
    /*
public override void Initialize(string object_name, int index)
    {
        if (dialogueName != null){
            dialogueName.text = object_name;
        }

        stateNameController.freezePlayer = true;

        List<List<string>> objectDialogue;
        if (!cutsceneData.cutsceneDictionary.TryGetValue(object_name, out objectDialogue)){
            Debug.Log("No dialogue found for " + object_name);
            lines = new List<string>() {"..."};
        }
        else{
            lines = cutsceneData.cutsceneDictionary[object_name][index];
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Audio/soundEffects/text");
        dialogueBox.text = "";
        StartDialogue();
    }
*/
}
