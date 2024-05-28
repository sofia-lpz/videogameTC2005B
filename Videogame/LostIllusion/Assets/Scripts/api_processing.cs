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
        tcgData.Cards = cardList.data;
    }

}
