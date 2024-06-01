using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyCard
{
    public Card card;
    public string card_name;
    public string card_description;
    public string card_energyCost;
    public int card_heal;
    public int card_damage;

    public EnemyCard(Card data)
    {
        card = data;
        card_name = card.name;
        card_description = card.description;
        card_energyCost = card.energy_cost.ToString();
        card_damage = card.player_attack;
        card_heal = card.player_health;
    }
}
