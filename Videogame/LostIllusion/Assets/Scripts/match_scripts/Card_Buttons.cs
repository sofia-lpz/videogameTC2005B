using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card_Buttons : MonoBehaviour
{
    [SerializeField] TMP_Text card_name;
    [SerializeField] TMP_Text card_description;
    [SerializeField] TMP_Text card_energyCost;
    [SerializeField] int card_damage;


    public Card card;

    // Start is called before the first frame update
    public void Init(Card data)
    {
        card = data;
        card_name.text = card.name;
        card_description.text = card.description;
        card_energyCost.text = card.energy_cost.ToString();
        card_damage = card.player_attack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
