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
    int index;
    AudioSource audioSource;
    private int charIndex = 0;

    // Start is called before the first frame update
    public virtual void Initialize(string object_name, int index)
    {
        if (dialogueName != null){
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

/*
uncomment this to start debugging pausing the dialogue

        for (i = charIndex; i < lines[index].ToCharArray.Length; i++)
        {
            dialogueBox.text += lines[index].ToCharArray[i];
            if (lines[index].ToCharArray[i] != ' '){
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.Play();
            }
            yield return new WaitForSeconds(textSpeed);
        }
*/



        foreach (char c in lines[index].ToCharArray())
        {
            dialogueBox.text += c;
            if (c != ' '){
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.Play();
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public virtual void NextLine()
    {
        if (index < lines.Count - 1)
        {
            index++;
            dialogueBox.text = "";
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

