using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colometaSceneManager : MonoBehaviour
{
    [SerializeField] public GameObject girlPrefab;

    void Start()
    {
        if (true)
        {
            Debug.Log("Centipede match won");
            GameObject.Find("CENTIPEDE").SetActive(false);
            GameObject player = GameObject.FindWithTag("Player");

            player.transform.position = new Vector3(0, 14, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
