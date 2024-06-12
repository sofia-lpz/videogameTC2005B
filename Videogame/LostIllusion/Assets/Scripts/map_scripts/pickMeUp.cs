/*
Script to pick up objects in the game
to use, simply attach to object you want to make pickable

Sofia Moreno
4/5/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickMeUp : collideableObject
{
    public bool interacted = false;
    [SerializeField] public GameObject prefabPickedObject;
    [SerializeField] public string cutsceneName;
    private MapManager MapManager;

    public override void Start()
    {
        base.Start();
        MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        if (stateNameController.playedCutscenes.Contains(cutsceneName)){
            Object.Instantiate(prefabPickedObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
    public override void onCollision(GameObject other)
    {
        base.onCollision(other);
        if (other.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Return)){
                onPickUp(other);
            }
        }
    }

    public virtual void onPickUp(GameObject other)
    {
        if (!interacted){
        interacted = true;
        Object.Instantiate(prefabPickedObject, transform.position, Quaternion.identity);

        stateNameController.inventory.Add(gameObject.name);
        Debug.Log("Picked up: " + stateNameController.inventory[stateNameController.inventory.Count - 1]);

        stateNameController.playerXPosInScene = other.transform.position.x;
        stateNameController.playerYPosInScene = other.transform.position.y;
        stateNameController.playerPreviousScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        MapManager.StartCutscene(cutsceneName);
        Destroy(gameObject);

        }
    }
}
