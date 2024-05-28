using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
}


[Serializable]
public class CardList
{
    public string status;
    public List<Card> data;
}

public class Player{
    public string username;
    public string password;
    public int matches_won;
}

public class Team{
    public string username;
    public string villager;
}

public class Villager{
    public string name;
    public string description;
    public string element;
}

public class Deck{
    public string username;
    public string cardId;
}

public class Stats{
    public string username;
    public string most_used_card;
    public string most_used_villager;
    public string least_used_card;
    public string least_used_villager;
    public int found_objects;
}

public class Match{
    public int matchId;
    public string timestamp;
    public string username;
    public bool won;
}
