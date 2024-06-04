/*
dialogue.cs

This script is responsible for managing the dialogue
It displays the dialogue text in a dialogue box and plays a sound effect for each character of the text. 
The script also allows the player to skip to the end of the current line of dialogue by pressing the space key. 
The dialogue text and speaker's name are stored in a dictionary in the dialogueData class. 
The script also changes the color of the text if the line is in the scaryLines list in the dialogueData class.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueBox;
    [SerializeField] TextMeshProUGUI dialogueName;
    List<string> lines;
    float textSpeed = 0.05f;
    float elipsisSpeed = 0.3f;
    int index;
    AudioSource audioSource;
    private string speaker_name;
    private Color originalColor;

    // Start is called before the first frame update
    public virtual void Initialize(string object_name, int index)
    {
        speaker_name = object_name;

        if (dialogueName != null && object_name != "NARRATOR" && object_name != "cutsceneStart"){
            dialogueName.text = object_name;
        }

        stateNameController.freezePlayer = true;

        List<List<string>> objectDialogue;
        if (!dialogueData.dialoguesDictionary.TryGetValue(object_name, out objectDialogue)){
            Debug.Log("No dialogue found for " + object_name);
            lines = new List<string>() {"..."};
        }
        else{
            lines = dialogueData.dialoguesDictionary[object_name][index];
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Audio/soundEffects/text");
        dialogueBox.text = "";
        StartDialogue();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        audioSource.volume = stateNameController.volume;
        
        if (stateNameController.gamePaused){
            StopAllCoroutines();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueBox.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueBox.text = lines[index];
            }
        }
    }

    public virtual void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public virtual IEnumerator TypeLine()
    {
        // Store the original color
        originalColor = dialogueBox.color;

        if (dialogueData.scaryLines.Contains(lines[index]))
        {
            // The line is in the scaryLines list
            // Change the color of the text
            dialogueBox.color = Color.grey; // Replace Color.red with the desired color
        }

        foreach (char c in lines[index].ToCharArray())
        {
            dialogueBox.text += c;
            if (c != ' ' && speaker_name != "NARRATOR" && speaker_name != "cutsceneStart"){
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.Play();
            }
            if (c == '.' || c == '?' || c == '!')
            {
                yield return new WaitForSeconds(elipsisSpeed);
            }
            else
            {
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    public virtual void NextLine()
    {
        if (index < lines.Count - 1)
        {
            index++;
            dialogueBox.text = "";
            dialogueBox.color = originalColor; // Restore the original color here
            StartCoroutine(TypeLine());
        }
        else
        {
            Destroy(gameObject);
            stateNameController.freezePlayer = false;
            Debug.Log("Dialogue canvas deleted.");
        }
    }
}