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

   public static Dictionary<string, Sprite> characterPortraits = new Dictionary<string, Sprite>
   {
      {"Cat", Resources.Load<Sprite>("character_portraits/reasonportrait")},
      {"Dream", Resources.Load<Sprite>("character_portraits/dreamportrait")},
      {"Terror", Resources.Load<Sprite>("character_portraits/terrorportrait")},
   };


   public static Dictionary<string, Sprite> cardSprites = new Dictionary<string, Sprite>
   {
      {"WISHBONE", Resources.Load<Sprite>("cardSprites/WISHBONE")}, // 1
      {"FLOWER", Resources.Load<Sprite>("cardSprites/FLOWER")}, // 2
      {"HAT", Resources.Load<Sprite>("cardSprites/HAT")}, // 3
      {"TOUCH", Resources.Load<Sprite>("cardSprites/TOUCH")}, // 4
      {"TASTE", Resources.Load<Sprite>("cardSprites/TASTE")}, // 5
      {"SMELL", Resources.Load<Sprite>("cardSprites/SMELL")}, // 6
      {"DREAM", Resources.Load<Sprite>("cardSprites/DREAM")}, // 7
      {"NIGHTMARE", Resources.Load<Sprite>("cardSprites/NIGHTMARE")}, // 8
      {"SLEEP", Resources.Load<Sprite>("cardSprites/SLEEP")}, // 9
      {"WAKE", Resources.Load<Sprite>("cardSprites/WAKE")}, // 10
      {"FORGET", Resources.Load<Sprite>("cardSprites/FORGET")}, // 11
      {"REMEMBER", Resources.Load<Sprite>("cardSprites/REMEMBER")}, // 12
      {"FEAR", Resources.Load<Sprite>("cardSprites/FEAR")}, // 13
      {"ANGER", Resources.Load<Sprite>("cardSprites/ANGER")}, // 14
      {"SADNESS", Resources.Load<Sprite>("cardSprites/SADNESS")}, // 15
      {"JOY", Resources.Load<Sprite>("cardSprites/JOY")}, // 16
      {"LOVE", Resources.Load<Sprite>("cardSprites/LOVE")}, // 17
      {"HATE", Resources.Load<Sprite>("cardSprites/HATE")}, // 18
      {"HOPE", Resources.Load<Sprite>("cardSprites/HOPE")}, // 19
      {"DESPAIR1", Resources.Load<Sprite>("cardSprites/DESPAIR1")}, // 20
      {"DESPAIR2", Resources.Load<Sprite>("cardSprites/DESPAIR2")}, // 21
      {"DESPAIR3", Resources.Load<Sprite>("cardSprites/DESPAIR3")}, // 22
      {"DESPAIR4", Resources.Load<Sprite>("cardSprites/DESPAIR4")}, // 23
      {"DESPAIR5", Resources.Load<Sprite>("cardSprites/DESPAIR5")}, // 24
      {"None", Resources.Load<Sprite>("cardSprites/None")}, // 25
   };

   public static Dictionary<int, int> cardUsesCount = new Dictionary<int, int>();
   public static Dictionary<int, int> villagerUsesCount = new Dictionary<int, int>();


}
