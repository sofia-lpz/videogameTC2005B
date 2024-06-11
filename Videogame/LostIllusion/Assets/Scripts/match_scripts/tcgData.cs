/*
tcgData.cs

This script is responsible for storing the data for the trading card game (TCG) elements in the game. 
It includes static lists for Cards and Villagers, which are populated with data retrieved from the API. 
These lists are used throughout the game to access the card and villager data as needed.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class tcgData
{
   public static List<Card> Cards = new List<Card>();

   public static List<Villager> Villagers = new List<Villager>();

   public static List<int> pickedCharacters = new List<int>();

   public static Dictionary<string, Sprite> elementSprites = new Dictionary<string, Sprite>
   {
      {"Reason", Resources.Load<Sprite>("emotion_ui/reasonsprite")},
      {"Dream", Resources.Load<Sprite>("emotion_ui/dreamsprite")},
      {"Terror", Resources.Load<Sprite>("emotion_ui/terrorsprite")},
   };

    public static Dictionary<int, int> cardUsesCount = new Dictionary<int, int>();


}
