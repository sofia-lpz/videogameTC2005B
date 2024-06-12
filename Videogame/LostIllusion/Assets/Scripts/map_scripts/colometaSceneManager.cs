using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colometaSceneManager : MonoBehaviour
{
    [SerializeField] public GameObject girlPrefab;
    private npcMovement npcMovement;
    [SerializeField] public Transform[] points;

    void Start()
    {
        if (stateNameController.match_CENTIPEDE == 1)
        {
            Debug.Log("Centipede match won");
            GameObject.Find("CENTIPEDE").SetActive(false);
            GameObject player = GameObject.FindWithTag("Player");

            player.transform.position = new Vector3(0, 14, 0);

            GameObject girl = Object.Instantiate(girlPrefab);
            girl.name = "GIRL";

            npcMovement = girl.GetComponent<npcMovement>();
            npcMovement.points = points;
            StartCoroutine(WaitForRoute());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForRoute()
    {
        yield return new WaitUntil(() => npcMovement.routineDone);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("youWon", LoadSceneMode.Single);
    }
}
