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
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine.SceneManagement;

public class TCG_Controller : MonoBehaviour
{
    [SerializeField] public string sceneName;
    [SerializeField] List<Card_Buttons> cards;
    [SerializeField] List<CharacterButtons> characterButtons;
    [SerializeField] List<CharacterButtons> enemyCharacterButtons;
    [SerializeField] int numInitialCards;
    [SerializeField] int cardsPerTurn;
    [SerializeField] int numCharacters;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] GameObject characterPrefab;
    [SerializeField] Transform enemyCharacterParent;
    [SerializeField] Transform buttonParentCards;
    [SerializeField] Transform characterParent;	
    [SerializeField] float delay;
    public TMP_Text EnergyText;
    public int energy;
    public TMP_Text notEnoughEnergyText;
    [SerializeField] Button endTurnButton;    
    [SerializeField] int maxCards;
    public enum Turn {Player, Enemy};
    public Turn currentTurn;
    public static int turnCount;

    [SerializeField] int limit = 1;


        [SerializeField] TextMeshPro card_name;

    [SerializeField] TextMeshPro card_energyCost;
    


    // to add pause, check stateNameController gamePaused; True menas paused, false means not paused

    // Start is called before the first frame update
    void Start()
    {
        currentTurn = Turn.Player;
        energy = Random.Range(4, 10);
        EnergyText.text = "Energy: " + energy.ToString();  
        endTurnButton.onClick.AddListener(EndTurn);
        StartCoroutine(PrepareCards());
        PrepareCharacters();
        PrepareEnemyCharacters();
        endTurnButton.interactable = currentTurn == Turn.Player;
        Invoke("SelectCharacter", 0.5f);
    }

    void SelectCharacter()
    {
        characterButtons[0].Highlight();
        enemyCharacterButtons[0].HighlightEnemy();
    }

    // Coroutine that prepares the cards
    IEnumerator PrepareCards()
    {
        
        int cardsToCreate = (turnCount == 0) ? numInitialCards: cardsPerTurn;
        cardsToCreate = Mathf.Min(cardsToCreate, maxCards - cards.Count);
        for (int i = 0; i < cardsToCreate; i++)
        {
            int cardID = Random.Range(0, tcgData.Cards.Count);
            GameObject newCard = Instantiate(buttonPrefab, buttonParentCards); 
            Card_Buttons cardButton = newCard.GetComponent<Card_Buttons>();
            cards.Add(cardButton);
            cardButton.Init(tcgData.Cards[cardID]);
            cardButton.gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonPressed(cardButton));
            yield return new WaitForSeconds(delay);
        }
        turnCount++;
    }

     CharacterButtons GetActiveEnemy()
    {
        foreach (CharacterButtons enemyCharacter in enemyCharacterButtons)
        {
            if (enemyCharacter.active)
            {
                return enemyCharacter;
            }
        }
        return null;
    }

    CharacterButtons GetActiveCharacter()
    {
        foreach (CharacterButtons character in characterButtons)
        {
            if (character.active)
            {
                return character;
            }
        }
        return null;
    }

    CharacterButtons GetInactiveEnemy()
    {
        foreach (CharacterButtons enemyCharacter in enemyCharacterButtons)
        {
            if (!enemyCharacter.active)
            {
                return enemyCharacter;
            }
        }
        return null;
    }

    // Function that is called when a card is pressed
    public void ButtonPressed(Card_Buttons cardButton)
    {
        if (currentTurn == Turn.Enemy)
        {
            return;

        } else {
            if (energy >= cardButton.card.energy_cost)
            {
                energy -= cardButton.card.energy_cost;
                EnergyText.text = "Energy: " + energy.ToString();
                cardButton.gameObject.GetComponent<Button>().interactable = false;
                cards.Remove(cardButton);
                Destroy(cardButton.gameObject);
                CharacterButtons activeEnemy = GetActiveEnemy();
                CharacterButtons inactiveEnemy = GetInactiveEnemy();
                CharacterButtons activeCharacter = GetActiveCharacter();

                if (activeEnemy != null)
                {
                    Debug.Log("Damage amount: " + cardButton.card.player_attack);
                    activeEnemy.TakeDamage(cardButton.card.player_attack);
                    activeCharacter.Heal(cardButton.card.player_health);
                   
                    if(activeEnemy.currentHealth <= 0 && inactiveEnemy.currentHealth <= 0)
                    {
                        activeEnemy.HighlightEnemy();
                        PlayerWins();
                    } else if(activeEnemy.currentHealth <= 0)
                    {
                        activeEnemy.HighlightEnemy();
                        inactiveEnemy.HighlightEnemy();
                    }
                }
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
                int charID = Random.Range(0, tcgData.Villagers.Count);
                GameObject newCharacter = Instantiate(characterPrefab, characterParent);
                CharacterButtons charButton = newCharacter.GetComponent<CharacterButtons>();
                characterButtons.Add(charButton);
                charButton.Init(tcgData.Villagers[charID]);
                Button buttonComponent = newCharacter.GetComponent<Button>();
                buttonComponent.onClick.AddListener(() => OnCharacterPressed(charButton));
            }
    }

    public void PrepareEnemyCharacters()
    {
        for (int i = 0; i < numCharacters; i++)
        {
            int charID = Random.Range(0, tcgData.Villagers.Count);
            GameObject newCharacter = Instantiate(characterPrefab, enemyCharacterParent);
            CharacterButtons charEnemyButton = newCharacter.GetComponent<CharacterButtons>();
            enemyCharacterButtons.Add(charEnemyButton);
            charEnemyButton.Init(tcgData.Villagers[charID]);
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
        CharacterButtons activeCharacter = GetActiveCharacter();
        activeCharacter.TakeDamage(4);
        yield return new WaitForSeconds(3);
        currentTurn = Turn.Player;
        endTurnButton.interactable = true;
        StartPlayerTurn();
    }

    void StartPlayerTurn()
    {
        energy = Random.Range(4, 10);
        limit = 1;
        EnergyText.text = "Energy: " + energy.ToString();
        StartCoroutine(PrepareCards());
    }

    public void OnCharacterPressed(CharacterButtons characterButton){
        if (currentTurn == Turn.Enemy)
        {
            return;
        } else {
            if (energy >= 1)
            {
                if (characterButton.active == false && limit > 0)
                {
                    for (int i = 0; i < numCharacters; i++)
                    {
                        characterButtons[i].Highlight();
                    }
                    energy -= 1;
                    EnergyText.text = "Energy: " + energy.ToString();
                    limit -= 1;
                }
            } else{
                if(Turn.Player == currentTurn) {
                    notEnoughEnergyText.text = "Not enough energy";
                }
            }
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void PlayerWins()
    {
        Debug.Log("Player wins");
        Invoke("LoadScene", 2);
    }

}


