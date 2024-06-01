/*
dialogueCutscenes.cs
TO DO: inherit dialogue.cs

This script is responsible for managing the dialogue in cutscenes
It displays the dialogue text in a dialogue box and plays a sound effect for each character of the text. 
The script also allows the player to skip to the end of the current line of dialogue by pressing the space key. 
The dialogue text and speaker's name are stored in a dictionary in the dialogueCutsceneData class. 
The script retrieves the dialogue based on the name of the active scene.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dialogueCutscenes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueBox;
    [SerializeField] TextMeshProUGUI dialogueName;
    
    List<string> lines;
    List<string> names;
    float textSpeed = 0.05f;
    float elipsisSpeed = 0.3f;
    int index;
    AudioSource audioSource;
    private int charIndex = 0;
    string cutsceneName;

    // Start is called before the first frame update
    public virtual void Initialize()
    {
        stateNameController.freezePlayer = true;

        cutsceneName = SceneManager.GetActiveScene().name;

        List<List<string>> cutsceneDialogue;
        if (!dialogueCutsceneData.dialoguesDictionary.TryGetValue(cutsceneName, out cutsceneDialogue))
        {
            Debug.Log("No dialogue found for " + cutsceneName);
            lines = new List<string>() { "..." };
            names = new List<string>() { "Unknown" };
        }
        else
        {
            lines = new List<string>();
            names = new List<string>();
            foreach (var dialogueLine in cutsceneDialogue)
            {
                names.Add(dialogueLine[0]);
                lines.Add(dialogueLine[1]);
            }
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Audio/soundEffects/text");
        dialogueBox.text = "";
        StartDialogue();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //audioSource.volume = stateNameController.volume;

        if (stateNameController.gamePaused)
        {
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
        UpdateDialogueName();
        StartCoroutine(TypeLine());
    }

    public virtual IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueBox.text += c;
            if (c != ' ')
            {
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
            UpdateDialogueName();
            StartCoroutine(TypeLine());
        }
        else
        {
            Destroy(gameObject);
            stateNameController.freezePlayer = false;
            Debug.Log("Dialogue canvas deleted.");
        }
    }

    private void UpdateDialogueName()
    {
        if (dialogueName != null && names.Count > index)
        {
            dialogueName.text = names[index];
        }
    }
}
