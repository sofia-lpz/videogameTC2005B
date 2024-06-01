/*
inventoryScript.cs

This script is responsible for managing the inventory system in the game. 
It creates an inventory slot for each item in the player's inventory at the start of the game. 
The inventory slot prefab is instantiated and parented to the game object this script is attached to. 
The number of items in the inventory is logged to the console for debugging purposes.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryScript : MonoBehaviour
{
    [SerializeField] public GameObject inventorySlotPrefab;

    void Start()
    {
        int numItems = stateNameController.inventory.Count;
        Debug.Log("Number of items in inventory: " + numItems);

        for (int i = 0; i < numItems; i++)
        {
            GameObject inventorySlot = Object.Instantiate(inventorySlotPrefab, transform);
        }
    }

}



