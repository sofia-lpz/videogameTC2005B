using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TCG_Controller : MonoBehaviour
{
    [SerializeField] List<Card_Buttons> cards;
    [SerializeField] int numCards;
    [SerializeField] int numCharacters;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] GameObject characterPrefab;
    [SerializeField] Transform buttonParentCards;
    [SerializeField] Transform characterParent;	
    [SerializeField] float delay;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(PrepareCards());
        PrepareCharacters();
    }

    IEnumerator PrepareCards()
    {
    for (int i = 0; i < numCards; i++)
        {
        GameObject newCard = Instantiate(buttonPrefab, buttonParentCards); 
        Card_Buttons cardButton = newCard.GetComponent<Card_Buttons>();
        cards.Add(cardButton);
        cardButton.gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonPressed(cardButton));
        yield return new WaitForSeconds(delay);
        }
    }

    public void ButtonPressed(Card_Buttons cardButton)
    {
    cards.Remove(cardButton);
    Destroy(cardButton.gameObject);
    }

    public void PrepareCharacters()
    {
    for (int i = 0; i < numCharacters; i++)
        {
            Instantiate(characterPrefab, characterParent);
        }
    }
}


