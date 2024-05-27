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


    public Card card;

    // Start is called before the first frame update
    public void Init(Card data)
    {
        card = data;
        card_name.text = card.name;
        card_description.text = card.description;
        card_energyCost.text = card.energy_cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
