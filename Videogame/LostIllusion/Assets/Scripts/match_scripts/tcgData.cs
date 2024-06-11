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

   //    public static Dictionary<int, int> cardUsesCount = new Dictionary<int, int>(){
   //    {Cards[0].cardID, 0},
   //    {Cards[1].cardID, 0},
   //    {Cards[2].cardID, 0},
   //    {Cards[3].cardID, 0},
   //    {Cards[4].cardID, 0},
   //    {Cards[5].cardID, 0},
   //    {Cards[6].cardID, 0},
   //    {Cards[7].cardID, 0},
   //    {Cards[8].cardID, 0},
   //    {Cards[9].cardID, 0},
   //    {Cards[10].cardID, 0},
   //    {Cards[11].cardID, 0},
   //    {Cards[12].cardID, 0},
   //    {Cards[13].cardID, 0},
   //    {Cards[14].cardID, 0},
   //    {Cards[15].cardID, 0},
   //    {Cards[16].cardID, 0},
   //    {Cards[17].cardID, 0},
   //    {Cards[18].cardID, 0},
   //    {Cards[19].cardID, 0},
   //    {Cards[20].cardID, 0},
   //    {Cards[21].cardID, 0},
   //    {Cards[22].cardID, 0},
   //    {Cards[23].cardID, 0}
   // };

}
