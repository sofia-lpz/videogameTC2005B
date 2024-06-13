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
      {"FISH", Resources.Load<Sprite>("character_portraits/fish")},
      {"CROW", Resources.Load<Sprite>("character_portraits/crow")},
      {"DOG", Resources.Load<Sprite>("character_portraits/dog")},
      {"BUNNY", Resources.Load<Sprite>("character_portraits/bunny")},
      {"ANGEL", Resources.Load<Sprite>("character_portraits/angel")},
      {"FRUIT", Resources.Load<Sprite>("character_portraits/watermelon")},
      {"None", Resources.Load<Sprite>("character_portraits/watermelon")},
   };


   public static Dictionary<string, Sprite> cardSprites = new Dictionary<string, Sprite>
   {
      {"WISHBONE", Resources.Load<Sprite>("cardSprites/WISHBONE")}, // 1
      {"3 LEAF CLOVER", Resources.Load<Sprite>("cardSprites/3_LEAF_CLOVER")},
      {"4 LEAF CLOVER", Resources.Load<Sprite>("cardSprites/4_LEAF_CLOVER")},
      {"5 LEAF CLOVER", Resources.Load<Sprite>("cardSprites/5_LEAF_CLOVER")},
      {"BANDAGE", Resources.Load<Sprite>("cardSprites/BANDAGE")},
      {"BAT", Resources.Load<Sprite>("cardSprites/BAT")},
      {"BIG AIRHORN", Resources.Load<Sprite>("cardSprites/BIG_AIRHORN")},
      {"SLEEP", Resources.Load<Sprite>("cardSprites/BLANKET")},
      {"BRACELET", Resources.Load<Sprite>("cardSprites/BRACELET")},
      {"CANDY", Resources.Load<Sprite>("cardSprites/CANDY")},
      {"GLASSES", Resources.Load<Sprite>("cardSprites/COOL_GLASSES")},
      {"FIRST AID KIT", Resources.Load<Sprite>("cardSprites/FIRST_AID_KIT")},
      {"FLASHLIGHT", Resources.Load<Sprite>("cardSprites/FLASHLIGHT")},
      {"FRIEND BRACELET", Resources.Load<Sprite>("cardSprites/FRIENDSHIP_BRACELET")},
      {"FRYING PAN", Resources.Load<Sprite>("cardSprites/FRYING_PAN")},
      {"GARDEN SHEARS", Resources.Load<Sprite>("cardSprites/GARDEN_SHEARS")},
      {"GRAPE SODA", Resources.Load<Sprite>("cardSprites/GRAPE_SODA")},
      {"JACKS", Resources.Load<Sprite>("cardSprites/JACK")},
      {"KNIFE", Resources.Load<Sprite>("cardSprites/KNIFE")},
      {"PINWHEEL", Resources.Load<Sprite>("cardSprites/PINWHEEL")},
      {"PRETTY BOW", Resources.Load<Sprite>("cardSprites/PRETTY_BOW")},
      {"RABBIT FOOT", Resources.Load<Sprite>("cardSprites/RABBIT_FOOT")},
      {"RAKE", Resources.Load<Sprite>("cardSprites/RAKE")},
      {"ROTTEN MILK", Resources.Load<Sprite>("cardSprites/ROTTEN_MILK")},
      {"SNOT", Resources.Load<Sprite>("cardSprites/SNOT")},
      {"TEAPOT", Resources.Load<Sprite>("cardSprites/TEAPOT")},
      {"SHARP TULIP", Resources.Load<Sprite>("cardSprites/TULIP_HAIRSTICK")},
      {"None", Resources.Load<Sprite>("cardSprites/JACK")},

   };

   public static Dictionary<int, int> cardUsesCount = new Dictionary<int, int>();
   public static Dictionary<int, int> villagerUsesCount = new Dictionary<int, int>();


}
