using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtons : MonoBehaviour
{
    public static CharacterButtons currentButton;
    [SerializeField] Color normalColor;
    [SerializeField] Color highlightColor = Color.yellow;
    [SerializeField] float initialPos;
    [SerializeField] float activePos;
    [SerializeField] float activePosE;
    [SerializeField] int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public bool active;

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

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
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
}
