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
    [SerializeField] public GameObject attackAnimationPrefab;
    [SerializeField] public GameObject fadeOutPrefab;
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
    private string sceneName = stateNameController.playerPreviousScene;
    private bool gameOver = false; 

    [SerializeField] int limit = 1;    


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

    CharacterButtons GetInactiveCharacter()
    {
        foreach (CharacterButtons character in characterButtons)
        {
            if (!character.active)
            {
                return character;
            }
        }
        return null;
    }

    // Function that is called when a card is pressed
    public void ButtonPressed(Card_Buttons cardButton)
    {
        if (currentTurn == Turn.Enemy || gameOver)
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

GameObject newAttackAnimation = Instantiate(attackAnimationPrefab);
newAttackAnimation.transform.localScale = new Vector3(2, 2, 2); // Change the 2s to your desired scale

                if (activeEnemy != null)
                {
                    if (cardButton.card.effect == "attack") 
                    {
                        if (activeCharacter.character.element == "Reason" && (activeEnemy.character.element == "Terror" || activeEnemy.character.element == "Spirit"))
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack + 1);
                        }
                        else if (activeCharacter.character.element == "Reason" && (activeEnemy.character.element == "Dream" || activeEnemy.character.element == "Ennvi"))
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack - 1);
                        }
                        else if (activeCharacter.character.element == "Terror" && (activeEnemy.character.element == "Ennvi" || activeEnemy.character.element == "Dream"))
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack + 1);
                        }
                        else if (activeCharacter.character.element == "Terror" && (activeEnemy.character.element == "Reason" || activeEnemy.character.element == "Spirit"))
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack - 1);
                        }
                        else if(activeCharacter.character.element == "Ennvi" && (activeEnemy.character.element == "Spirit" || activeEnemy.character.element == "Reason"))
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack + 1);
                        }
                        else if(activeCharacter.character.element == "Ennvi" && (activeEnemy.character.element == "Terror" || activeEnemy.character.element == "Dream"))
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack - 1);
                        }
                        else if(activeCharacter.character.element == "Spirit" && (activeEnemy.character.element == "Dream" || activeEnemy.character.element == "Terror"))
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack + 1);
                        }
                        else if(activeCharacter.character.element == "Spirit" && (activeEnemy.character.element == "Ennvi" || activeEnemy.character.element == "Reason"))
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack - 1);
                        }
                        else if(activeCharacter.character.element == "Dream" && (activeEnemy.character.element == "Reason" || activeEnemy.character.element == "Ennvi"))
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack + 1);
                        }
                        else if(activeCharacter.character.element == "Dream" && (activeEnemy.character.element == "Spirit" || activeEnemy.character.element == "Terror"))
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack - 1);
                        }
                        else 
                        {
                            activeEnemy.TakeDamage(cardButton.card.player_attack);
                        }
                    } 
                    else if (cardButton.card.effect == "support") 
                    {
                        activeCharacter.Heal(cardButton.card.player_health);
                    }
                    else if (cardButton.card.effect == "defense")
                    {
                        Debug.Log("Defense");
                    }
                    
                   
                    if(activeEnemy.currentHealth <= 0 && inactiveEnemy.currentHealth <= 0)
                    {
                        activeEnemy.HighlightEnemy();
                        PlayerWins();
                    } 
                    else if(activeEnemy.currentHealth <= 0)
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
        CharacterButtons inactiveCharacter = GetInactiveCharacter();
        activeCharacter.TakeDamage(4);
        
        if(activeCharacter.currentHealth <= 0 && inactiveCharacter.currentHealth <= 0)
        {
            activeCharacter.Highlight();
            EnemyWins();
        }
        else if(activeCharacter.currentHealth <= 0)
        {
            activeCharacter.Highlight();
            inactiveCharacter.Highlight();
        }

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
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        GameObject fadeOut = Instantiate(fadeOutPrefab);

    }

    public void PlayerWins()
    {
        Debug.Log("Player wins");
        gameOver = true;
        resultHandler.match_won();
        Invoke("LoadScene", 5);
    }

    public void EnemyWins()
    {
        Debug.Log("Enemy wins");
        gameOver = true;
        resultHandler.match_lost();
        Invoke("LoadScene", 5);
    }

}


