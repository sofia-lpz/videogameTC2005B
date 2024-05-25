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
    [SerializeField] int maxHealth = 10;
    [SerializeField] int currentHealth;
    public HealthBar healthBar;
    public bool active;

    // Start is called before the first frame update
     public void Start()
    {
        healthBar = GetComponent<HealthBar>();
        initialPos = transform.position.y;
        activePos = initialPos + 15f;
        normalColor = GetComponent<Image>().color;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
}
