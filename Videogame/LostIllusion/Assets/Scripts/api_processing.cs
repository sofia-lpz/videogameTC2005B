using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class api_processing : MonoBehaviour
{
    void CardProcessing(string cardResults)
    {
        cardData cardList = JsonUtility.FromJson<cardData>(cardResults);

        foreach (card c in cardList.cards)
        {
            card newCard = new card();
            newCard.cardID = c.cardID;
            newCard.name = c.name;
            newCard.energy_cost = c.energy_cost;
            newCard.effect = c.effect;
            newCard.type = c.type;
            newCard.description = c.description;
            newCard.player_health = c.player_health;
            newCard.player_attack = c.player_attack;
            newCard.player_defense = c.player_defense;
            newCard.player_support = c.player_support;
            newCard.enemy_defense = c.enemy_defense;

            cardList.cards.Add(newCard);
        }
    }
}