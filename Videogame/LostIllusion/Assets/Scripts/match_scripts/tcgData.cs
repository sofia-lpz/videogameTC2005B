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

   public static Sprite[] Charms = Resources.LoadAll<Sprite>("cardSprites/charms");


   public static Dictionary<string, Sprite> cardSprites = new Dictionary<string, Sprite>
   {
      {"WISHBONE", Charms[20]}, // 1
      {"FLOWER", Charms[1]}, // 2
      {"HAT", Charms[2]}, // 3
      {"TOUCH", Charms[3]}, // 4
      {"TASTE", Charms[4]}, // 5
      {"SMELL", Charms[5]}, // 6
      {"DREAM", Charms[6]}, // 7
      {"NIGHTMARE", Charms[7]}, // 8
      {"SLEEP", Charms[8]}, // 9
      {"WAKE", Charms[9]}, // 10
      {"FORGET", Charms[10]}, // 11
      {"REMEMBER", Charms[11]}, // 12
      {"FEAR", Charms[12]}, // 13
      {"ANGER", Charms[13]}, // 14
      {"SADNESS", Charms[14]}, // 15
      {"JOY", Charms[15]}, // 16
      {"LOVE", Charms[16]}, // 17
      {"HATE", Charms[17]}, // 18
      {"HOPE", Charms[18]}, // 19
      {"DESPAIR1", Charms[19]}, // 20
      {"DESPAIR2", Charms[21]}, // 21
      {"DESPAIR3", Charms[22]}, // 22
      {"DESPAIR4", Charms[23]}, // 23
      {"DESPAIR5", Charms[24]}, // 24
      {"None", Charms[25]}, // 25
   };

   public static Dictionary<int, int> cardUsesCount = new Dictionary<int, int>();
   public static Dictionary<int, int> villagerUsesCount = new Dictionary<int, int>();


}
