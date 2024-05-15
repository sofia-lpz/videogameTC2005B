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



