using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class api_post : MonoBehaviour
{

//para llamarlo cuando se acabe la match de acuerdo al tcg_controller
    public void postData(string mostUsedCard, string mostUsedVillager, string leastUsedCard, string leastUsedVillager, int memoriesFound)
    {
        StartCoroutine(PostStatsData(stateNameController.Players[0].username, mostUsedCard, mostUsedVillager, leastUsedCard, leastUsedVillager, memoriesFound));
    }

    public void postMatchData(bool won)
    {
        StartCoroutine(PostMatchesData(stateNameController.Players[0].username, won));
    }


//post de ejemplo, es para hacer registro
public IEnumerator PostStatsData(string username, string mostUsedCard, string mostUsedVillager, string leastUsedCard, string leastUsedVillager, int memoriesFound)
{
    WWWForm form = new WWWForm();
    form.AddField("username", username);
    form.AddField("mostUsedCard", mostUsedCard);
    form.AddField("mostUsedVillager", mostUsedVillager);
    form.AddField("leastUsedCard", leastUsedCard);
    form.AddField("leastUsedVillager", leastUsedVillager);
    form.AddField("memoriesFound", memoriesFound);

    using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/api/create/stats", form))
    {
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

public IEnumerator PostMatchesData(string username, bool won)
{
    string wonstring = won ? "true" : "false";

    WWWForm form = new WWWForm();
    form.AddField("username", username);
    form.AddField("won", wonstring);

    using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/api/create/match", form))
    {
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
