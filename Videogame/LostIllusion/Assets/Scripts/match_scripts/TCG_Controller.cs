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
    [SerializeField] public GameObject supportAnimationPrefab;
    [SerializeField] public GameObject defenseAnimationPrefab;
    [SerializeField] public GameObject attackAnimationPrefab;
    [SerializeField] public GameObject healingAnimationPrefab;
    [SerializeField] public GameObject specialAnimationPrefab;
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
    //private string sceneName = COLOMETA;
    private bool gameOver = false; 

    private tcgFeedback feedbackscript;
    private List<int> usedCharacters = new List<int>();
    private List<int> usedEnemyCharacters = new List<int>();
    public bool skipEnemyTurn = false;
    private api_post Apipost;

    [SerializeField] int limit = 1;    


    // to add pause, check stateNameController gamePaused; True menas paused, false means not paused

    // Start is called before the first frame update
    void Start(){
        Apipost = GetComponent<api_post>();
        tcgData.villagerUsesCount[tcgData.pickedCharacters[0]] += 1;
        tcgData.villagerUsesCount[tcgData.pickedCharacters[1]] += 1;
        //Apipost.postVillagerUse();
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

        energy = Random.Range(4, 10);
        EnergyText.text = "Energy: " + energy.ToString();  
        endTurnButton.onClick.AddListener(EndTurn);
        StartCoroutine(PrepareCards());
        PrepareCharacters();
        PrepareEnemyCharacters();
        PrepareEnemyCards();
        endTurnButton.interactable = currentTurn == Turn.Player;
        Invoke("SelectCharacter", 2.0f);
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

                if (tcgData.cardUsesCount.ContainsKey(cardButton.card.cardId))
                {
                    tcgData.cardUsesCount[cardButton.card.cardId] += 1;
                }

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
                            feedbackscript.ShowFeedback("You used " + cardButton.card.name + " attacked and dealt " + ApplyCardAttack(cardButton.card, activeCharacter, activeEnemy) + " damage!");
                            Instantiate(attackAnimationPrefab);
                            break;
                        
                        case "support":
                            if (cardButton.card.enemy_attack > 0)
                            {
                                feedbackscript.ShowFeedback("You used " + cardButton.card.name + " and decreased enemy's attack by " + ApplySupportEffect(cardButton.card, activeCharacter, activeEnemy) + "!");
                            }
                            else if (cardButton.card.player_support > 0)
                            {
                                feedbackscript.ShowFeedback("You used " + cardButton.card.name + " and increased your attack by " + ApplySupportEffect(cardButton.card, activeCharacter, activeEnemy) + "!");
                            }

                            Instantiate(supportAnimationPrefab);
                            break;
                        
                        case "defense":
                            if (cardButton.card.enemy_defense > 0)
                            {
                                feedbackscript.ShowFeedback("You used " + cardButton.card.name + " and decreased enemy's defense by " + ApplyDefenseEffect(cardButton.card, activeCharacter, activeEnemy) + "!");
                            }
                            else if (cardButton.card.player_defense > 0)
                            {
                                feedbackscript.ShowFeedback("You used " + cardButton.card.name + " and increased your defense by " + ApplyDefenseEffect(cardButton.card, activeCharacter, activeEnemy) + "!");
                            }

                            Instantiate(defenseAnimationPrefab);
                            break;
                        
                        case "healing":
                            feedbackscript.ShowFeedback("You used " + cardButton.card.name + " and healed " + cardButton.card.player_health + " health!");
                            activeCharacter.Heal(cardButton.card.player_health);
                            Instantiate(healingAnimationPrefab);
                            break;

                        case "special":    
                            skipEnemyTurn = true;
                            Instantiate(specialAnimationPrefab);
                            feedbackscript.ShowFeedback("You used " + cardButton.card.name + " and skiped enemy's turn!");
                            break;

                        default:
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
                }
            }
        }
    }

    public int ApplyCardAttack(Card card, CharacterButtons attackingCharacter, CharacterButtons defendingCharacter){
        int damage = card.player_attack + attackingCharacter.currentAttack;

        // Apply elemental advantage/disadvantage
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
            defendingCharacter.defenseText.text = defendingCharacter.currentDefense.ToString();
        }
        else
        {
            damage -= defendingCharacter.currentDefense;
        }
        
        if (damage < 0) damage = 0;

        if (damage == 0) feedbackscript.ShowFeedback("Attack was not effective!");

        defendingCharacter.TakeDamage(damage);
        return damage;
    }

    private int ApplySupportEffect(Card card, CharacterButtons activeCharacter, CharacterButtons activeEnemy){
        if (card.player_support > 0)
        {
            activeCharacter.IncreaseAttack(card.player_support);
            return card.player_support;
        }
        if (card.enemy_attack > 0)
        {
            activeEnemy.DecreaseAttack(card.enemy_attack);
            return card.enemy_attack;           
        }
        return 0;
    }

    private int ApplyDefenseEffect(Card card, CharacterButtons activeCharacter, CharacterButtons activeEnemy){
        if (card.enemy_defense > 0)
        {
            activeEnemy.DecreaseDefense(card.enemy_defense);
            return card.enemy_defense;
        }
        if (card.player_defense > 0)
        {
            activeCharacter.IncreaseDefense(card.player_defense);
            return card.player_defense;
        }
        return 0;
    }

    // Function that prepares the characters
    // agregar condicion para que no se repitan los personajes
    public void PrepareCharacters(){ 
        for (int i = 0; i < numCharacters; i++)
        {
            int charID = tcgData.pickedCharacters[i] - 1;
        
            GameObject newCharacter = Instantiate(characterPrefab, characterParent);
            Vector3 pos = newCharacter.transform.position;
            pos.x = pos.x + i * 300 - 150; 
            newCharacter.transform.position = pos;
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
            int charID;

            do {charID = Random.Range(0, tcgData.Villagers.Count);} while (usedEnemyCharacters.Contains(charID));
            usedEnemyCharacters.Add(charID);

            GameObject newCharacter = Instantiate(characterPrefab, enemyCharacterParent);
            Vector3 pos = newCharacter.transform.position;
            pos.x = pos.x + i * 300 - 150;
            newCharacter.transform.position = pos;
            CharacterButtons charEnemyButton = newCharacter.GetComponent<CharacterButtons>();
            enemyCharacterButtons.Add(charEnemyButton);
            charEnemyButton.Init(tcgData.Villagers[charID]);
        }
    }

    public bool HasAdvantage(CharacterButtons attacker, CharacterButtons defender){
        string attackerElement = attacker.character.element;
        string defenderElement = defender.character.element;

        if ((attackerElement == "Reason" && defenderElement == "Terror") || (attackerElement == "Terror" && defenderElement == "Dream") || (attackerElement == "Dream" && defenderElement == "Reason"))
        {
            return true;
        }

        return false;
    }


    // Function that ends the turn
    public void EndTurn(){
        currentTurn = Turn.Enemy;
        endTurnButton.interactable = false;

        if (skipEnemyTurn)
        {
            skipEnemyTurn = false;
            StartPlayerTurn();
            return;
        } 
        else 
        {
             StartCoroutine(EnemyTurn());
        }
       
        notEnoughEnergyText.text = "";
    }

    // Coroutine that simulates the enemy turn
    public IEnumerator EnemyTurn(){
        feedbackscript.ShowFeedback("Enemy's turn!");
        yield return new WaitForSeconds(3);
        enemyEnergy = Random.Range(3, 7);
        feedbackscript.ShowFeedback("Enemy got " + enemyEnergy + " energy!");
        yield return new WaitForSeconds(4);

        CharacterButtons activePlayerCharacter = GetActiveCharacter();
        CharacterButtons activeEnemyCharacter = GetActiveEnemy();
        CharacterButtons inactiveEnemyCharacter = GetInactiveEnemy();
        
        float changeCharacterProb = 0.5f;

        if (!HasAdvantage(activeEnemyCharacter, activePlayerCharacter))
        {
            // Decidir si cambiar de personaje basado en la probabilidad fija
            if (Random.value < changeCharacterProb && inactiveEnemyCharacter.currentHealth > 0)
            {
                feedbackscript.ShowFeedback("Enemy switches character!");
                activeEnemyCharacter.HighlightEnemy();
                inactiveEnemyCharacter.HighlightEnemy();
                yield return new WaitForSeconds(2);
            }
        }

        float endTurnProb = 0f;

        while (enemyEnergy >= 0 && enemyCards.Count >= 0)
        {
            EnemyCard selectedCard = SelectEnemyCard();
            if (selectedCard != null && enemyEnergy >= selectedCard.card.energy_cost)
            {
                enemyEnergy -= selectedCard.card.energy_cost;
                CharacterButtons activePlayerCharacter1 = GetActiveCharacter();
                CharacterButtons activeEnemyCharacter1 = GetActiveEnemy();

                switch (selectedCard.card.effect)
                {
                    case "attack":
                        Instantiate(attackAnimationPrefab);
                        feedbackscript.ShowFeedback("Enemy uses " + selectedCard.card_name + " attacks and deals " + ApplyCardAttack(selectedCard.card, activeEnemyCharacter1, activePlayerCharacter1) + " damage!");
                        break;

                    case "support":
                        Instantiate(supportAnimationPrefab);

                        if (selectedCard.card.enemy_attack > 0)
                        {
                            feedbackscript.ShowFeedback("Enemy used " + selectedCard.card.name + " and decreased your attack by " + ApplySupportEffect(selectedCard.card, activeEnemyCharacter1, activePlayerCharacter1) + "!");
                        }
                        else if (selectedCard.card.player_support > 0)
                        {
                            feedbackscript.ShowFeedback("Enemy used " + selectedCard.card.name + " and increased his attack by " + ApplySupportEffect(selectedCard.card, activeEnemyCharacter1, activePlayerCharacter1) + "!");
                        }
                        break;

                    case "defense":
                        Instantiate(defenseAnimationPrefab);
                        if (selectedCard.card.enemy_defense > 0)
                        {
                            feedbackscript.ShowFeedback("Enemy uses " + selectedCard.card_name + " and decreases your defense by " + selectedCard.card.enemy_defense +"!");
                        }
                        else if (selectedCard.card.player_defense > 0)
                        {
                            feedbackscript.ShowFeedback("Enemy uses " + selectedCard.card_name + " and increases his defense by " + selectedCard.card.player_defense + "!");
                        }
                        
                        break;

                    case "healing":
                        activeEnemyCharacter.Heal(selectedCard.card.player_health);
                        Instantiate(healingAnimationPrefab);
                        feedbackscript.ShowFeedback("Enemy uses " + selectedCard.card_name + " and heals " + selectedCard.card.player_health + "!");
                        break;

                    default:
                        break;
                }

                enemyCards.Remove(selectedCard);
                yield return new WaitForSeconds(3);

                if (Random.value < endTurnProb)
                {
                    feedbackscript.ShowFeedback("Enemy ends turn!");
                    break;
                }

                endTurnProb += 0.25f;
            }
            else
            {
                feedbackscript.ShowFeedback("Enemy ends turn!");
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
            activeCharacter.GetComponent<Button>().interactable = false;   
            activeCharacter.Highlight();
            inactiveCharacter.Highlight();
        }

        yield return new WaitForSeconds(2);
        feedbackscript.ShowFeedback("Your turn!");
        PrepareEnemyCards();
        StartPlayerTurn();
    }

    public EnemyCard SelectEnemyCard(){
        List<EnemyCard> affordableCards = enemyCards.FindAll(card => card.card.energy_cost <= enemyEnergy);

        if (affordableCards.Count == 0)
        {
            return null;
        }

        affordableCards.Sort((card1, card2) => card1.card.energy_cost.CompareTo(card2.card.energy_cost));

        float errorMargin = 0.9f;
        int maxIndex = Mathf.CeilToInt(affordableCards.Count * errorMargin);
        EnemyCard selectedCard = affordableCards[Random.Range(0, maxIndex)];
        return selectedCard;
    }

    public void StartPlayerTurn(){
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

    public IEnumerator LoadScene(string sceneName){
        yield return new WaitForSeconds(5);
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        Instantiate(fadeOutPrefab);
    }

    public void PlayerWins()
    {
        feedbackscript.ShowFeedback("You win!");
        gameOver = true;
        //Apipost.postMatchData(true);
        //Apipost.postCardUse();
        resultHandler.match_won();
        StartCoroutine(LoadScene("youWincutscene"));
    }

    public void EnemyWins()
    {
        feedbackscript.ShowFeedback("You lose!");
        gameOver = true;
        //Apipost.postMatchData(false);
        //Apipost.postCardUse();
        resultHandler.match_lost();
        StartCoroutine(LoadScene("gameOver"));
    }

}