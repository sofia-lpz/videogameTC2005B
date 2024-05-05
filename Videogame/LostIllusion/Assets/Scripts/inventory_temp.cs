/*
File to temporarily hold the player's inventory
to be later replaced by a database and api
Might be kept for the access layer of the api

Sofia Moreno
4/5/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_temp : MonoBehaviour
{
    [SerializeField] public static List<string> inventory = new List<string>();
}
