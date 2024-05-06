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
    public void Initialize(string object_name, string object_type)
    {
        if (object_type == "enemy")
        {
            lines = new List<string>
            {
                "Hello, I am Mr. " + object_name + ".",
                "I am here to fight you.",
                "Press the space bar to continue."
            };
            dialogueName.text = object_name;
        }
        else if (object_type == "pickable")
        {
            lines = new List<string>
            {
                "You've picked up a " + object_name + ".",
                "neat!"
            };
        }
        else if (object_type == "chatter")
        {
            lines = new List<string>
            {
                "Hello, I am " + object_name + ".",
                "I am here to talk to you.",
                "bla bla bla bla"
            };
            dialogueName.text = object_name;
        }
        
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Audio/soundEffects/text");
        dialogueBox.text = "";
        StartDialogue();
    }
    

    // Update is called once per frame
    void Update()
    {
        
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

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
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

    public void NextLine()
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

