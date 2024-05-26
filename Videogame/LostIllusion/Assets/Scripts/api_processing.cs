using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // for Action<string>

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

public class api_processing : MonoBehaviour
{
    

    public static void CardProcessing(string result)
    {
        Debug.Log("api_processing got: " + result);
        CardList cardList = JsonUtility.FromJson<CardList>(result);
        tcgData.Cards = cardList.data;
    }
}
