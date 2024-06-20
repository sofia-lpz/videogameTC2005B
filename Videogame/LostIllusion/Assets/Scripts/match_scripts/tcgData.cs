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
   public static List<Card> Cards = new List<Card>(){
      new Card (1, "BANDAGE", 3, "healing", "snack", "Using this grants 3 hp", 3, 0, 0, 0, 0, 0),
      new Card (2, "FIRST AID KIT", 1, "healing", "snack", "Using this grants 1 hp", 1, 0, 0, 0, 0, 0),
      new Card (3, "CANDY", 2, "healing", "snack", "This candy grants 2 hp", 2, 0, 0, 0, 0, 0),
      new Card (4, "GRAPE SODA", 3, "healing", "skill", "drink and heal 3 hp", 3, 0, 0, 0, 0, 0),
      new Card (5, "KNIFE", 3, "attack", "skill", "deals 3 damage points to the opponent", 0, 3, 0, 0, 0, 0),
      new Card (11, "BAT", 2, "attack", "weapon", "deals 2 damage to the opponent", 0, 2, 0, 0, 0, 0),
      new Card (12, "RAKE", 2, "attack", "hypnosis", "deals 2 damage to the opponent", 0, 2, 0, 0, 0, 0),
      new Card (20, "TEAPOT", 3, "attack", "skill", "deals 3 damage to the opponent", 0, 3, 0, 0, 0, 0),
      new Card (21, "FRYING PAN", 1, "attack", "skill", "deals 1 damage to opponent", 0, 1, 0, 0, 0, 0),
      new Card (22, "GARDEN SHEARS", 1, "attack", "skill", "deals 2 damage to the opponent", 0, 2, 0, 0, 0, 0),
      new Card (23, "FLASHLIGHT", 3, "attack", "skill", "deals 3 damage to the opponent", 0, 3, 0, 0, 0, 0),
      new Card (24, "SHARP TULIP", 2, "attack", "skill", "deals 3 damage to the opponent", 0, 3, 0, 0, 0, 0),
      new Card (15, "PINWHEEL", 2, "attack", "skill", "deals 2 damage to the opponent", 0, 2, 0, 0, 0, 0),
      new Card (13, "JACKS", 1, "attack", "weapon", "deals 1 damage to the opponent", 0, 1, 0, 0, 0, 0),
      new Card (7, "BRACELET", 1, "defense", "skill", "increases defense by 1 point", 0, 0, 1, 0, 0, 0),
      new Card (17, "GLASSES", 1, "defense", "skill", "increases defense by 1 point", 0, 0, 1, 0, 0, 0),
      new Card (18, "RED BRACELET", 1, "defense", "skill", "decreases the enemy defense by 1 point", 0, 0, 0, 0, 1, 0),
      new Card (19, "PRETTY BOW", 2, "defense", "skill", "decreases the enemy defense by 2 points", 0, 0, 0, 0, 2, 0),
      new Card (6, "RABBIT FOOT", 1, "support", "skill", "increases attack by 1 point", 0, 0, 0, 1, 0, 0),
      new Card (8, "4 LEAF CLOVER", 2, "support", "skill", "increases attack by 2 points", 0, 0, 0, 2, 0, 0),
      new Card (9, "3 LEAF CLOVER", 3, "support", "snack", "lowers enemy attack by 1 point", 0, 0, 0, 0, 0, 1),
      new Card (10, "5 LEAF CLOVER", 2, "support", "creature", "lowers enemy attack by 2 points", 0, 0, 0, 0, 0, 2),
      new Card (16, "WISHBONE", 3, "support", "skill", "decreases the enemy attack by 2 points", 0, 0, 0, 0, 0, 2),
      new Card (14, "SLEEP", 3, "special", "hypnosis", "skips enemy turn", 0, 0, 0, 0, 0, 0),
   };

   public static List<Villager> Villagers = new List<Villager>(){
      new Villager(1, "DOG", "Its your cat!", "Reason"),
      new Villager(2, "FISH", "Possesed doll", "Terror"),
      new Villager(3, "ANGEL", "A random sheep that escaped from a farm. Not very interested in going back", "Dream"),
      new Villager(4, "FRUIT", "A bird that is always chirping", "Reason"),
      new Villager(5, "CROW", "A ghost that haunts the house", "Terror"),
      new Villager(6, "BUNNY", "A bluejay that is always flying", "Dream"),
   };

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

   public static Dictionary<int, int> cardUsesCount = new Dictionary<int, int>()
   {
      {1, 0},
      {2, 0},
      {3, 0},
      {4, 0},
      {5, 0},
      {6, 0},
      {7, 0},
      {8, 0},
      {9, 0},
      {10, 0},
      {11, 0},
      {12, 0},
      {13, 0},
      {14, 0},
      {15, 0},
      {16, 0},
      {17, 0},
      {18, 0},
      {19, 0},
      {20, 0},
      {21, 0},
      {22, 0},
      {23, 0},
      {24, 0},
   };
   public static Dictionary<int, int> villagerUsesCount = new Dictionary<int, int>(){
      {1, 0},
      {2, 0},
      {3, 0},
      {4, 0},
      {5, 0},
      {6, 0},
   };


}
