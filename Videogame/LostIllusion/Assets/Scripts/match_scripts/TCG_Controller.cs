/*
    Script that works as the main controller for the TCG match,
*/
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
    [SerializeField] int numInitialCards;
    [SerializeField] int cardsPerTurn;
    [SerializeField] int numCharacters;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] GameObject characterPrefab;
    [SerializeField] Transform buttonParentCards;
    [SerializeField] Transform characterParent;	
    [SerializeField] float delay;
    [SerializeField] TMP_Text EnergyText;
    [SerializeField] int energy;
    [SerializeField] TMP_Text notEnoughEnergyText;
    [SerializeField] Button endTurnButton;    
    public enum Turn {Player, Enemy};
    public Turn currentTurn;
    private int turnCount;

    // Start is called before the first frame update
    void Start()
    {
        currentTurn = Turn.Player;
        EnergyText.text = "Energy: " + energy.ToString();  
        endTurnButton.onClick.AddListener(EndTurn); 
        StartCoroutine(PrepareCards());
        PrepareCharacters();
        endTurnButton.interactable = currentTurn == Turn.Player;
    }

    // Coroutine that prepares the cards
    IEnumerator PrepareCards()
    {
        int cardsToCreate = (turnCount == 0) ? numInitialCards: cardsPerTurn;
        for (int i = 0; i < cardsToCreate; i++)
            {
            GameObject newCard = Instantiate(buttonPrefab, buttonParentCards); 
            Card_Buttons cardButton = newCard.GetComponent<Card_Buttons>();
            cards.Add(cardButton);
            cardButton.gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonPressed(cardButton));
            yield return new WaitForSeconds(delay);
            }
            turnCount++;
    }

    // Function that is called when a card is pressed
    public void ButtonPressed(Card_Buttons cardButton)
    {
        if (currentTurn == Turn.Enemy)
        {
            return;
        } else {
            if (energy >= cardButton.energyCost)
            {
                energy -= cardButton.energyCost;
                EnergyText.text = "Energy: " + energy.ToString();
                cardButton.gameObject.GetComponent<Button>().interactable = false;
                cards.Remove(cardButton);
                Destroy(cardButton.gameObject);
            } else {
                if(Turn.Player == currentTurn)
                notEnoughEnergyText.text = "Not enough energy";
                Debug.Log("Not enough energy");
            }
        }
    }

    // Function that prepares the characters
    public void PrepareCharacters()
    {
        for (int i = 0; i < numCharacters; i++)
            {
                Instantiate(characterPrefab, characterParent);
            }
    }

    // Function that ends the turn
    public void EndTurn()
    {
        currentTurn = Turn.Enemy;
        endTurnButton.interactable = false;
        StartCoroutine(EnemyTurn());
        notEnoughEnergyText.text = "";
    }

    // Coroutine that simulates the enemy turn
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(10);
        currentTurn = Turn.Player;
        endTurnButton.interactable = true;
        StartPlayerTurn();
    }

    void StartPlayerTurn()
    {
        energy = Random.Range(1, 10);
        EnergyText.text = "Energy: " + energy.ToString();
        StartCoroutine(PrepareCards());
    }
}


