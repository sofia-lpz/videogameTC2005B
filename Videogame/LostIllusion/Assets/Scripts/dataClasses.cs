/*
dataClasses.cs

This script defines the data structures for Cards and Players in the game. 
It includes classes for individual Cards and Players, as well as classes for lists of Cards and Players. 
Each class is marked as Serializable, allowing it to be converted to and from a JSON string for API communication. 
The Card class includes properties for the card's ID, name, energy cost, effect, type, description, and various stats. 
The Player class includes properties for the player's username, password, number of matches won, and level.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class carduse{
    public string cardId;
    public int timesUsed;
}

[Serializable]
public class carduseList{
    public string username;
    public List<carduse> cards;
}

[Serializable]
public class villageruse{
    public string villagerId;
    public int timesUsed;
}

[Serializable]
public class villageruseList{
    public string username;
    public List<villageruse> villagers;
}

[Serializable]
public class Card
{
    public int cardId;
    public string name;
    public int energy_cost;
    public string effect;
    public string type;
    public string description;
    public int player_health;
    public int player_attack;
    public int player_defense;
    public int player_support;
    public int enemy_defense;
    public int enemy_attack;

    public Card(int cardId, string name, int energy_cost, string effect, string type, string description, int player_health, int player_attack, int player_defense, int player_support, int enemy_defense, int enemy_attack)
    {
        this.cardId = cardId;
        this.name = name;
        this.energy_cost = energy_cost;
        this.effect = effect;
        this.type = type;
        this.description = description;
        this.player_health = player_health;
        this.player_attack = player_attack;
        this.player_defense = player_defense;
        this.player_support = player_support;
        this.enemy_defense = enemy_defense;
        this.enemy_attack = enemy_attack;
    }
}

[Serializable]
public class CardList
{
    public string status;
    public List<Card> data;
}

[Serializable]
public class Player{
    public string username;
    public string password;
}

[Serializable]
public class PlayerList{
    public string status;
    public List<Player> data;
}





[Serializable]
public class PlayerStats{
    public string status;
    public List<Stats> data;
}

[Serializable]
public class Team{
    public string username;
    public string villager;
}

[Serializable]
public class Villager{
    public int villager_id;
    public string name;
    public string description;
    public string element;

    public Villager(int villager_id, string name, string description, string element)
    {
        this.villager_id = villager_id;
        this.name = name;
        this.description = description;
        this.element = element;
    }
}

[Serializable]
public class VillagerList{
    public string status;
    public List<Villager> data;
}

[Serializable]
public class Deck{
    public string username;
    public string cardId;
}

[Serializable]
public class Stats{
    public string username;
    public string most_used_card;
    public string most_used_villager;
    public string least_used_card;
    public string least_used_villager;
    public int found_objects;
}

[Serializable]
public class Match{
    public int matchId;
    public string timestamp;
    public string username;
    public bool won;
}

[Serializable]
public class MatchList{
    public string status;
    public List<Match> data;
}