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
using UnityEngine.SceneManagement;

public class TCG_Controller : MonoBehaviour
{
    [SerializeField] public GameObject attackAnimationPrefab;
    [SerializeField] public GameObject fadeOutPrefab;
    [SerializeField] List<Card_Buttons> cards;
    [SerializeField] List<EnemyCard> enemyCards = new List<EnemyCard>();
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
    public int enemyEnergy;
    public TMP_Text notEnoughEnergyText;
    [SerializeField] Button endTurnButton;    
    [SerializeField] int maxCards;
    public enum Turn {Player, Enemy};
    public Turn currentTurn;
    public static int turnCount;
    private string sceneName = stateNameController.playerPreviousScene;
    private bool gameOver = false; 

    private tcgFeedback feedbackscript;


    [SerializeField] int limit = 1;    


    // to add pause, check stateNameController gamePaused; True menas paused, false means not paused

    // Start is called before the first frame update
    void Start(){
        feedbackscript = GetComponent<tcgFeedback>();
        
        currentTurn = (Turn)Random.Range(0, 2);
        if (currentTurn == Turn.Enemy)
        {
            StartCoroutine(EnemyTurn());
            feedbackscript.ShowFeedback("The enemy has the first turn!");
        }
        else
        {
            feedbackscript.ShowFeedback("You have the first turn!");
        }

        Debug.Log("Current turn: " + currentTurn);
        energy = Random.Range(4, 10);
        EnergyText.text = "Energy: " + energy.ToString();  
        endTurnButton.onClick.AddListener(EndTurn);
        StartCoroutine(PrepareCards());
        PrepareCharacters();
        PrepareEnemyCharacters();
        PrepareEnemyCards();
        endTurnButton.interactable = currentTurn == Turn.Player;
        Invoke("SelectCharacter", 0.5f);
    }

    void SelectCharacter(){
        characterButtons[0].Highlight();
        enemyCharacterButtons[0].HighlightEnemy();
    }

    // Coroutine that prepares the cards
    IEnumerator PrepareCards(){
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

    public void PrepareEnemyCards(){
        int cardsToCreate = (turnCount == 0) ? numInitialCards: cardsPerTurn;
        cardsToCreate = Mathf.Min(cardsToCreate, maxCards - enemyCards.Count);
        for (int i = 0; i < cardsToCreate; i++)
        {
            int cardID = Random.Range(0, tcgData.Cards.Count); 
            EnemyCard enemyCard = new EnemyCard(tcgData.Cards[cardID]);
            enemyCards.Add(enemyCard);
        }
    }

     CharacterButtons GetActiveEnemy(){
        foreach (CharacterButtons enemyCharacter in enemyCharacterButtons)
        {
            if (enemyCharacter.active)
            {
                return enemyCharacter;
            }
        }
        return null;
    }

    CharacterButtons GetActiveCharacter(){
        foreach (CharacterButtons character in characterButtons)
        {
            if (character.active)
            {
                return character;
            }
        }
        return null;
    }

    CharacterButtons GetInactiveEnemy(){
        foreach (CharacterButtons enemyCharacter in enemyCharacterButtons)
        {
            if (!enemyCharacter.active)
            {
                return enemyCharacter;
            }
        }
        return null;
    }

    CharacterButtons GetInactiveCharacter(){
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
    public void ButtonPressed(Card_Buttons cardButton){
        if (currentTurn == Turn.Enemy || gameOver)
        {
            return;
        } 
        else 
        {
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
                    switch (cardButton.card.effect)
                    {
                        case "attack":
                            ApplyCardAttack(cardButton.card, activeCharacter, activeEnemy);
                            Instantiate(attackAnimationPrefab);
                            break;
                        
                        case "support":
                            ApplySupportEffect(cardButton.card, activeCharacter, activeEnemy);
                            break;
                        
                        case "defense":
                            ApplyDefenseEffect(cardButton.card, activeCharacter, activeEnemy);
                            break;
                        
                        case "healing":
                            activeCharacter.Heal(cardButton.card.player_health);
                            break;
                        
                        default:
                            Debug.LogWarning("Unknown card effect: " + cardButton.card.effect);
                            break;
                    }

                    if (activeEnemy.currentHealth <= 0 && inactiveEnemy.currentHealth <= 0)
                    {
                        activeEnemy.HighlightEnemy();
                        PlayerWins();
                    } 
                    else if (activeEnemy.currentHealth <= 0)
                    {
                        activeEnemy.HighlightEnemy();
                        inactiveEnemy.HighlightEnemy();
                    }
                }
            } 
            else 
            {
                if (Turn.Player == currentTurn)
                {
                    notEnoughEnergyText.text = "Not enough energy";
                    Debug.Log("Not enough energy");
                }
            }
        }
    }

    public void ApplyCardAttack(Card card, CharacterButtons attackingCharacter, CharacterButtons defendingCharacter){
        int damage = card.player_attack + attackingCharacter.currentAttack;

        /* Elemental advantage/disadvantage adjustments
        if (attackingCharacter.character.element == "Reason" && (defendingCharacter.character.element == "Terror" || defendingCharacter.character.element == "Spirit"))
        {
            damage += 1;
        }
        else if (attackingCharacter.character.element == "Reason" && (defendingCharacter.character.element == "Dream" || defendingCharacter.character.element == "Ennui"))
        {
            damage -= 1;
        }
        else if (attackingCharacter.character.element == "Terror" && (defendingCharacter.character.element == "Ennui" || defendingCharacter.character.element == "Dream"))
        {
            damage += 1;
        }
        else if (attackingCharacter.character.element == "Terror" && (defendingCharacter.character.element == "Reason" || defendingCharacter.character.element == "Spirit"))
        {
            damage -= 1;
        }
        else if (attackingCharacter.character.element == "Ennui" && (defendingCharacter.character.element == "Spirit" || defendingCharacter.character.element == "Reason"))
        {
            damage += 1;
        }
        else if (attackingCharacter.character.element == "Ennui" && (defendingCharacter.character.element == "Terror" || defendingCharacter.character.element == "Dream"))
        {
            damage -= 1;
        }
        else if (attackingCharacter.character.element == "Spirit" && (defendingCharacter.character.element == "Dream" || defendingCharacter.character.element == "Terror"))
        {
            damage += 1;
        }
        else if (attackingCharacter.character.element == "Spirit" && (defendingCharacter.character.element == "Ennui" || defendingCharacter.character.element == "Reason"))
        {
            damage -= 1;
        }
        else if (attackingCharacter.character.element == "Dream" && (defendingCharacter.character.element == "Reason" || defendingCharacter.character.element == "Ennui"))
        {
            damage += 1;
        }
        else if (attackingCharacter.character.element == "Dream" && (defendingCharacter.character.element == "Spirit" || defendingCharacter.character.element == "Terror"))
        {
            damage -= 1;
        } */

        if (attackingCharacter.character.element == "Reason" && defendingCharacter.character.element == "Terror")
        {
            damage += 1;
        }
        else if (attackingCharacter.character.element == "Reason" && defendingCharacter.character.element == "Dream")
        {
            damage -= 1;
        }
        else if (attackingCharacter.character.element == "Terror" && defendingCharacter.character.element == "Dream")
        {
            damage += 1;
        }
        else if (attackingCharacter.character.element == "Terror" && defendingCharacter.character.element == "Reason")
        {
            damage -= 1;
        }
        else if (attackingCharacter.character.element == "Dream" && defendingCharacter.character.element == "Reason")
        {
            damage += 1;
        }
        else if (attackingCharacter.character.element == "Dream" && defendingCharacter.character.element == "Terror")
        {
            damage -= 1;
        }

        // Apply defense reduction
        if (defendingCharacter.currentDefense > 0)
        {
            damage /= 2;
            defendingCharacter.DecreaseDefense(1);
        }
        else
        {
            damage -= defendingCharacter.currentDefense;
        }
        
        if (damage < 0) damage = 0;

        defendingCharacter.TakeDamage(damage);
    }

    private void ApplySupportEffect(Card card, CharacterButtons activeCharacter, CharacterButtons activeEnemy){
        if (card.player_defense > 0)
        {
            activeCharacter.IncreaseDefense(card.player_defense);
        }

        if (card.player_support > 0)
        {
            activeCharacter.IncreaseAttack(card.player_support);
        }

        if (card.enemy_defense > 0)
        {
            activeEnemy.DecreaseDefense(card.enemy_defense);
        }
        if (card.enemy_attack > 0)
        {
            activeEnemy.DecreaseAttack(card.enemy_attack);
        }

        Debug.Log("Applied support effect: " + card.description);
    }

    private void ApplyDefenseEffect(Card card, CharacterButtons activeCharacter, CharacterButtons activeEnemy){
        if (card.enemy_attack > 0)
        {
            activeEnemy.DecreaseAttack(card.player_attack);
        }
        if (card.player_defense > 0)
        {
            activeCharacter.IncreaseDefense(card.player_defense);
        }

        Debug.Log("Applied defense effect: " + card.description);
    }

    // Function that prepares the characters
    // agregar condicion para que no se repitan los personajes
    public void PrepareCharacters(){
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

    public void PrepareEnemyCharacters(){
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
    public void EndTurn(){
        currentTurn = Turn.Enemy;
        endTurnButton.interactable = false;
        StartCoroutine(EnemyTurn());
        notEnoughEnergyText.text = "";
    }

    // Coroutine that simulates the enemy turn
    public IEnumerator EnemyTurn(){
        feedbackscript.ShowFeedback("Enemy's turn!");
        yield return new WaitForSeconds(3);
        enemyEnergy = Random.Range(4, 10);
        feedbackscript.ShowFeedback("Enemy got " + enemyEnergy + " energy!");
        yield return new WaitForSeconds(4);

        while (enemyEnergy > 0 && enemyCards.Count > 0)
        {
            EnemyCard selectedCard = SelectEnemyCard();
            if (selectedCard != null && enemyEnergy >= selectedCard.card.energy_cost)
            {
                Debug.Log("Selected Card: " + selectedCard.card.name + " with cost: " + selectedCard.card.energy_cost);
                enemyEnergy -= selectedCard.card.energy_cost;
                CharacterButtons activePlayerCharacter = GetActiveCharacter();
                CharacterButtons inactiveEnemyCharacter = GetInactiveEnemy();
                CharacterButtons activeEnemyCharacter = GetActiveEnemy();

                switch (selectedCard.card.effect)
                {
                    case "attack":
                        ApplyCardAttack(selectedCard.card, activeEnemyCharacter, activePlayerCharacter);
                        Instantiate(attackAnimationPrefab);
                        Debug.Log("Enemy attacks");
                        feedbackscript.ShowFeedback("Enemy attacks!");
                        break;

                    case "support":
                        ApplySupportEffect(selectedCard.card, activeEnemyCharacter, activePlayerCharacter);
                        Debug.Log("Enemy supports");
                        feedbackscript.ShowFeedback("Enemy supports!");
                        break;

                    case "defense":
                        ApplyDefenseEffect(selectedCard.card, activeEnemyCharacter, activePlayerCharacter);
                        Debug.Log("Enemy defends");
                        feedbackscript.ShowFeedback("Enemy defends!");
                        break;

                    case "healing":
                        if (selectedCard.card_name == "bandage")
                        {
                            activeEnemyCharacter.Heal(selectedCard.card_heal);
                            inactiveEnemyCharacter.Heal(selectedCard.card_heal);
                            Debug.Log("Both characters healed by " + selectedCard.card_heal);
                            feedbackscript.ShowFeedback("Both characters healed by " + selectedCard.card_heal);
                        }else {
                            activeEnemyCharacter.Heal(selectedCard.card.player_health);
                            feedbackscript.ShowFeedback("Enemy heals!");
                            Debug.Log("Enemy heals");
                        }
                        break;

                    default:
                        Debug.LogWarning("Unknown card effect: " + selectedCard.card.effect);
                        break;
                }

                enemyCards.Remove(selectedCard);
                yield return new WaitForSeconds(3);  // Optional: Add delay between plays
            }
            else
            {
                Debug.Log("Enemy couldn't play any card due to insufficient energy or other constraints");
                break;
            }
        }

        // Check if player characters are defeated
        CharacterButtons activeCharacter = GetActiveCharacter();
        CharacterButtons inactiveCharacter = GetInactiveCharacter();
        if (activeCharacter.currentHealth <= 0 && inactiveCharacter.currentHealth <= 0)
        {
            activeCharacter.Highlight();
            EnemyWins();
        }
        else if (activeCharacter.currentHealth <= 0)
        {
            activeCharacter.Highlight();
            inactiveCharacter.Highlight();
        }

        yield return new WaitForSeconds(1);  // Optional: Add delay before switching turn back to player
        Debug.Log("Enemy Turn Ended");
        feedbackscript.ShowFeedback("Your turn!");
        PrepareEnemyCards();
        StartPlayerTurn();
    }

    public EnemyCard SelectEnemyCard(){
        List<EnemyCard> affordableCards = enemyCards.FindAll(card => card.card.energy_cost <= enemyEnergy);

        if (affordableCards.Count == 0)
        {
            Debug.Log("No affordable cards");
            return null;
        }

        affordableCards.Sort((card1, card2) => card1.card.energy_cost.CompareTo(card2.card.energy_cost));

        float errorMargin = 0.50f;
        int maxIndex = Mathf.CeilToInt(affordableCards.Count * errorMargin);
        EnemyCard selectedCard = affordableCards[Random.Range(0, maxIndex)];
        Debug.Log("Selected Card for AI: " + selectedCard.card.name);
        return selectedCard;
    }

    public void StartPlayerTurn(){
        Debug.Log("Player Turn Started");
        feedbackscript.ShowFeedback("Your turn!");
        energy = Random.Range(4, 10);
        limit = 1;
        EnergyText.text = "Energy: " + energy.ToString();
        endTurnButton.interactable = true;
        currentTurn = Turn.Player;
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
        Instantiate(fadeOutPrefab);

    }

    public void PlayerWins()
    {
        Debug.Log("Player wins");
        feedbackscript.ShowFeedback("You win!");
        gameOver = true;
        resultHandler.match_won();
        Invoke("LoadScene", 5);
    }

    public void EnemyWins()
    {
        Debug.Log("Enemy wins");
        feedbackscript.ShowFeedback("You lose!");
        gameOver = true;
        resultHandler.match_lost();
        Invoke("LoadScene", 5);
    }

}