/*
EnemyCard.cs

This script is responsible for managing the enemy cards in the trading card game. 
It includes a Card object and properties for the card's name, description, energy cost, heal value, and damage value. 
The EnemyCard constructor takes a Card object as input and initializes the properties with the data from the Card object. 
This script is used to create enemy card objects that can be used in the game to represent the cards in the enemy's deck.

Luis Filorio
*/
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
