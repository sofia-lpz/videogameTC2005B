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

    // Start is called before the first frame update
    void Start()
    {
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
        
        if (currentButton != null)
        {
            currentButton.GetComponent<Image>().color = currentButton.normalColor;
            currentButton.transform.position = new Vector3(currentButton.transform.position.x, currentButton.initialPos, currentButton.transform.position.z);
        }

        currentButton = this;
        initialPos = transform.position.y;
        activePos = initialPos + 15f;
        GetComponent<Image>().color = highlightColor;
        transform.position = new Vector3(transform.position.x, activePos, transform.position.z);
    }
}
