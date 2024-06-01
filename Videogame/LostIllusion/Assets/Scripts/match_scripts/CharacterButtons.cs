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
    [SerializeField] TMP_Text characterName;
    [SerializeField] TMP_Text characterDescription;
     [SerializeField] TMP_Text characterElement;

    public int currentHealth ;
    public HealthBar healthBar;
    public bool active;
    public int currentAttack ;
    public int currentDefense ;

    public Villager character;

    // Start is called before the first frame update
     public void Start()
    {
        healthBar = GetComponent<HealthBar>();
        initialPos = transform.position.y;
        activePos = initialPos + 15f;
        activePosE = initialPos - 15f;
        normalColor = GetComponent<Image>().color;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);  
    }

    public void Init(Villager data)
    {
        character = data;
        characterName.text = character.name;
        characterDescription.text = character.description;
        characterElement.text = character.element;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0; // Ensure health doesn't go negative
        Debug.Log("Took damage: " + amount + ", Current Health: " + currentHealth);
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
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
        Debug.Log("Increased defense by " + amount);
    }

    public void IncreaseAttack(int amount)
    {
        currentAttack += amount;
        Debug.Log("Increased attack by " + amount);
    }

    public void DecreaseDefense(int amount)
    {
        currentDefense -= amount;
        if (currentDefense < 0) currentDefense = 0;
        Debug.Log("Decreased defense by " + amount);
    }

    public void DecreaseAttack(int amount)
    {
        currentAttack -= amount;
        if (currentAttack < 0) currentAttack = 0;
        Debug.Log("Decreased attack by " + amount);
    }
}
