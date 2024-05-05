using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] List<string> lines;
    [SerializeField] float textSpeed = 0.05f;
    [SerializeField] int index;
    AudioSource audioSource;
    [SerializeField] float minPitch = 0.9f;
    [SerializeField] float maxPitch = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        lines = new List<string>
        {
            "Hello, I am a dialogue box.",
            "I am here to help you.",
            "Press the space bar to continue.",
            "I will disappear after the last line.",
            "Goodbye!"
        };
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Audio/soundEffects/text");
        textComponent.text = "";
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
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
            textComponent.text += c;
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
            textComponent.text = "";
            StartCoroutine(TypeLine());
        }
        else
        {
            Destroy(transform.parent.gameObject);
            Debug.Log("Dialogue canvas deleted.");
        }
    }
}

