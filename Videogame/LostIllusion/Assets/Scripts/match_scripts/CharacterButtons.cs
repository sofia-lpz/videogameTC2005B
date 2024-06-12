/*
CharacterButtons.cs

This script is responsible for managing the character buttons in the game. 
Each character button is associated with a Villager object, which contains data such as the character's name, description, and element. 
The Init method is used to initialize the character button with the data from a Villager object. 
The character's name, description, and element are displayed on the button using TextMeshPro text fields. 
The script also manages the character's health bar and active status, and includes methods for updating the health bar and toggling the active status.

Luis Filorio
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterButtons : MonoBehaviour
{
    public static CharacterButtons currentButton;
    [SerializeField] Color normalColor;
    [SerializeField] Color highlightColor = Color.yellow;
    [SerializeField] float initialPos;
    [SerializeField] float activePos;
    [SerializeField] float activePosE;
    [SerializeField] int maxHealth = 10;
    [SerializeField] int maxDefense = 5;
    [SerializeField] TMP_Text characterName;
    [SerializeField] TMP_Text characterElement;
    [SerializeField] TMP_Text healthText;
    [SerializeField] public TMP_Text defenseText;

    public int currentHealth;
    public int currentDefense;
    
    public HealthBar healthBar;
    public DefenseBar defenseBar;
    public bool active;
    public int currentAttack;
    

    public Villager character;

    // Start is called before the first frame update
     public void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        defenseBar = GetComponentInChildren<DefenseBar>();
        initialPos = transform.position.y;
        activePos = initialPos + 18f;
        activePosE = initialPos - 18f;
        normalColor = GetComponent<Image>().color;
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString();
        currentDefense = 3;
        defenseBar.SetMaxDefense(maxDefense);
        defenseBar.SetDefense(currentDefense);
        defenseText.text = currentDefense.ToString();
        healthBar.SetMaxHealth(maxHealth);  
    }

    public void Init(Villager data)
    {
        character = data;
        characterName.text = character.name;
        characterElement.text = character.element;
    
        if (tcgData.elementSprites.TryGetValue(character.element, out Sprite elementSprite))
        {
            Transform childTransform = transform.Find("backgroundColor");
            if (childTransform != null)
            {
                Image imageComponent = childTransform.GetComponent<Image>();
                if (imageComponent != null)
                {
                    imageComponent.sprite = elementSprite;
                }
            }
        }
    }

    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0; // Ensure health doesn't go negative
        healthBar.SetHealth(currentHealth);
        healthText.text = currentHealth.ToString();
        Debug.Log("Took damage: " + amount + ", Current Health: " + currentHealth);
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth) currentHealth = maxHealth; // Ensure health doesn't exceed max health
        healthBar.SetHealth(currentHealth); 
        healthText.text = currentHealth.ToString();
    }

    public void Highlight()
    {
        
       if (active) 
       {
            GetComponent<Image>().color = normalColor;
            transform.position = new Vector3(transform.position.x, initialPos, transform.position.z);
            active = false;

       } else {
            GetComponent<Image>().color = highlightColor;
            transform.position = new Vector3(transform.position.x, activePos, transform.position.z);
            active = true;
       }
        
    }

    public void HighlightEnemy()
    {
        if (active) 
        {
            GetComponent<Image>().color = normalColor;
            transform.position = new Vector3(transform.position.x, initialPos, transform.position.z);
            active = false;

        } else {
            GetComponent<Image>().color = highlightColor;
            transform.position = new Vector3(transform.position.x, activePosE, transform.position.z);
            active = true;
        }
    }

    public void IncreaseDefense(int amount)
    {
        currentDefense += amount;
        if (currentDefense > maxDefense) currentDefense = maxDefense;
        defenseBar.SetDefense(currentDefense);
        defenseText.text = currentDefense.ToString();
        Debug.Log("Increased defense by " + amount);
    }

    public void IncreaseAttack(int amount)
    {
        currentAttack += amount;
        if (currentAttack > 3) currentAttack = 3;
        Debug.Log("Increased attack by " + amount);
    }

    public void DecreaseDefense(int amount)
    {
        currentDefense -= amount;
        if (currentDefense < 0) currentDefense = 0;
        defenseBar.SetDefense(currentDefense);
        defenseText.text = currentDefense.ToString();
        Debug.Log("Decreased defense by " + amount);
    }

    public void DecreaseAttack(int amount)
    {
        currentAttack -= amount;
        if (currentAttack < 0) currentAttack = 0;
        Debug.Log("Decreased attack by " + amount);
    }
}
