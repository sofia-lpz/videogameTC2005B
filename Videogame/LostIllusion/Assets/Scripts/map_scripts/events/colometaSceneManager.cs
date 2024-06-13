using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colometaSceneManager : MonoBehaviour
{
    [SerializeField] public GameObject girlPrefab;
    private npcMovement npcMovement;
    [SerializeField] public Transform[] points;
    [SerializeField] public AudioClip newBgMusicClip;
    GameObject centipede;

    void Start()
    {
        if (stateNameController.match_CENTIPEDE == 1)
            {
                // Get the child object
    Transform childTransform = transform.Find("BgSoundManager");
    if (childTransform != null)
    {
        // Get the BgSoundManager component
        BgSoundManager bgSoundManager = childTransform.GetComponent<BgSoundManager>();
        if (bgSoundManager != null)
        {
            // Load a different bgMusic
            bgSoundManager.bgMusic = newBgMusicClip;
            // Restart the audio source to play the new bgMusic
            bgSoundManager.audioSource1.Stop();
            bgSoundManager.audioSource1.clip = newBgMusicClip;
            bgSoundManager.audioSource1.Play();
        }
    }
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
        else
        {
            Debug.Log("Centipede match lost");
            centipede = GameObject.Find("CENTIPEDE");
            centipede.SetActive(true);
            centipede.GetComponent<npcMovement>().enabled = true;
        }
        
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
