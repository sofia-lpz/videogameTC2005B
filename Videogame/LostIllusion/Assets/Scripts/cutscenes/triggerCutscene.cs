using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class triggerCutscene : triggerableObject
{
    [SerializeField] public bool interacted = false;
    [SerializeField] public GameObject CutsceneCanvasPrefab;
    [SerializeField] public string cutsceneName;


    public override void Start()
    {
        base.Start();
if (stateNameController.playedCutscenes.Contains(cutsceneName)){
            Destroy(gameObject);
        }
    }

    public override void onTriggerEnter(GameObject other)
    {
        base.onTriggerEnter(other);

        stateNameController.playerXPosInScene = other.transform.position.x;
        stateNameController.playerYPosInScene = other.transform.position.y;

        if (other.tag == "Player" && !interacted){
            StartCoroutine(StartCutscene());
            interacted = true;
        }
    }

    IEnumerator StartCutscene()
    {
        GameObject cutsceneCanvas = Object.Instantiate(CutsceneCanvasPrefab);
        cutsceneCanvas.GetComponent<dialogue>().Initialize(gameObject.name, 0);
        yield return new WaitForSeconds(3);
        Destroy(cutsceneCanvas);
        SceneManager.LoadScene(cutsceneName); 
    }


}
