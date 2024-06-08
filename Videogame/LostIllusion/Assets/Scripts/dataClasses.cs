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
public class Card
{
    public int cardID;
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
    public int matches_won;
    public int level;
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
    public int villagerID;
    public string name;
    public string description;
    public string element;
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