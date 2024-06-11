/*
Card_Buttons.cs

This script is responsible for managing the card buttons in the trading card game. 
Each card button is associated with a Card object, which contains data such as the card's name, description, energy cost, damage, and heal values. 
The Init method is used to initialize the card button with the data from a Card object. 
The card's name, description, and energy cost are displayed on the button using TextMeshPro text fields.

Luis Filorio
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card_Buttons : MonoBehaviour
{
    [SerializeField] public TMP_Text card_name;
    [SerializeField] TMP_Text card_description;
    [SerializeField] TMP_Text card_energyCost;
    [SerializeField] Image cardImage;
    public int card_heal;
    public int card_damage;


    public Card card;

    // Start is called before the first frame update
    public void Init(Card data)
    {
        card = data;
        card_name.text = card.name;
        card_description.text = card.description;
        card_energyCost.text = card.energy_cost.ToString();
        card_damage = card.player_attack;
        card_heal = card.player_health;
    
        Sprite cardSprite;
        if (!tcgData.cardSprites.TryGetValue(card.name, out cardSprite))
        {
            tcgData.cardSprites.TryGetValue("None", out cardSprite);
        }
    
        Transform childTransform = transform.Find("CardImage");
        if (childTransform != null)
        {
            Image imageComponent = childTransform.GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.sprite = cardSprite;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
