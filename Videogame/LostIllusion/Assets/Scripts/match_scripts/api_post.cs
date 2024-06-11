using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class api_post : MonoBehaviour
{
    public void postCardUse()
    {
        StartCoroutine(PostCardUseData());
    }

    public void postVillagerUse()
    {
        StartCoroutine(PostVillagerUseData());
    }   

    public void postMatchData(bool won)
    {
        StartCoroutine(PostMatchesData(stateNameController.Players[0].username, won));
    }


public IEnumerator PostMatchesData(string username, bool won){
    string wonstring = won ? "true" : "false";

    string body = "{\"username\":\"" + username + "\",\"won\":\"" + wonstring + "\"}";
    Debug.Log(body);

    using (UnityWebRequest www = UnityWebRequest.Put("http://localhost:3000/api/create/match", body))
    {
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Post failed: " + www.error);
        }
        else
        {
            string result = www.downloadHandler.text;
            Debug.Log("Post successful: " + result);
        }
    }
}

public IEnumerator PostCardUseData(){
    carduseList carduseList = new carduseList();
    carduseList.username = stateNameController.Players[0].username;
    carduseList.cards = new List<carduse>();

    foreach (KeyValuePair<int, int> entry in tcgData.cardUsesCount)
    {
        carduse carduse = new carduse();
        carduse.cardId = entry.Key.ToString();
        carduse.timesUsed = entry.Value;
        carduseList.cards.Add(carduse);
    }

    string body = JsonUtility.ToJson(carduseList);
    Debug.Log("body for card use" + body);

    using (UnityWebRequest www = UnityWebRequest.Put("http://localhost:3000/api/update/carduse", body))
    {
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Post failed: " + www.error);
        }
        else
        {
            string result = www.downloadHandler.text;
            Debug.Log("Post successful: " + result);
        }
    }

}

public IEnumerator PostVillagerUseData(){
    villageruseList villageruseList = new villageruseList();
    villageruseList.username = stateNameController.Players[0].username;
    villageruseList.villagers = new List<villageruse>();

    foreach (KeyValuePair<int, int> entry in tcgData.villagerUsesCount)
    {
        villageruse villageruse = new villageruse();
        villageruse.villagerId = entry.Key.ToString();
        villageruse.timesUsed = entry.Value;
        villageruseList.villagers.Add(villageruse);
    }

    string body = JsonUtility.ToJson(villageruseList);
    Debug.Log(body);

    using (UnityWebRequest www = UnityWebRequest.Put("http://localhost:3000/api/update/villageruse", body))
    {
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Post failed: " + www.error);
        }
        else
        {
            string result = www.downloadHandler.text;
            Debug.Log("Post successful: " + result);
        }
    }

}

}