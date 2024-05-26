using System.Collections;
using System.Collections.Generic;

[System.Serializable]


public class cardData
{
    public static List<card> cardList = new List<card>();
}

public class card
{
    public int cardID;
    public string name;
    public int energy_cost;
    public string effect;
    public string type;
    public int description;
    public int player_health;
    public int player_attack;
    public int player_defense;
    public int player_support;
    public int enemy_defense;
}
