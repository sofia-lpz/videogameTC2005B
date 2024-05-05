/*
This script keeps the picked up objects destroyed across scenes

Sofia Moreno
5/5/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistDestroyed : MonoBehaviour
{
void Start()
{
    // Destroy all picked up items
    foreach (string pickedUpItem in stateNameController.inventory)
    {
        Destroy(GameObject.Find(pickedUpItem));
    }
}

}
