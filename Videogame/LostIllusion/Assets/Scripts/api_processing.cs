using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // for Action<string>

public class api_processing : MonoBehaviour
{
    
    public static void CardProcessing(string result)
    {
        Debug.Log("api_processing got: " + result);
        CardList cardList = JsonUtility.FromJson<CardList>(result);
        Debug.Log("cardList: " + cardList.data[0].name);
        Debug.Log("cardList status: " + cardList.status);
        tcgData.Cards = cardList.data;
    }

    public static void VillagerProcessing(string result)
    {
        Debug.Log("api_processing got: " + result);
        VillagerList villagerList = JsonUtility.FromJson<VillagerList>(result);
        Debug.Log("villagerList: " + villagerList.data[0].name);
        Debug.Log("villagerList status: " + villagerList.status);
        tcgData.Villagers = villagerList.data;
    }

    public static void PlayerProcessing(string result)
    {
        Debug.Log("api_processing got: " + result);
        PlayerList playerList = JsonUtility.FromJson<PlayerList>(result);
        
        Debug.Log("player status: " + playerList.status);
        stateNameController.playerStatus = playerList.status;

        stateNameController.Players = playerList.data;
    }



}
