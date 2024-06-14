using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colometaSceneManager : MonoBehaviour
{

    private npcMovement npcMovement;


    void Start()
    {

                GameObject girl = GameObject.Find("GIRL");
             

                npcMovement = girl.GetComponent<npcMovement>();

                StartCoroutine(WaitForRoute());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForRoute()
    {
        yield return new WaitUntil(() => npcMovement.routineDone);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("youWon", LoadSceneMode.Single);
    }
}
