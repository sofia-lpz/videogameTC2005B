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

    // Start is called before the first frame update
    public virtual void Initialize(string object_name, int index)
    {
        if (dialogueName != null){
            dialogueName.text = object_name;
        }
        
        lines = stateNameController.dialoguesDictionary[object_name][index];
        
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
            Debug.Log("Dialogue canvas deleted.");
        }
    }
}

