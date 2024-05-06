/*
File to hold variables across scenes

Sofia Moreno
4/5/2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateNameController : MonoBehaviour
{
    // To use, call stateNameController.theNameOfYourVariable
    // and access it from any script in any scene you want
    
    //this script doesn't need to be attached to any object


    //for example in this format
    public static List<string> scenes = new List<string> {
        "Home",
        "Outside",
        };

    [SerializeField] public static string player_username = "Dev";
    [SerializeField] public static string enemy_name = "nombre";
    [SerializeField] public static int player_level = 0;
    [SerializeField] public static List<string> inventory = new List<string>();
    

    public static List<string> tv_init_lines = new List<string> {
        "Hola " + player_username,
        "QUE?",
        "QUIERES UNA PELEA?",
        "TE DARE UNA PELEA",
    };
    public static List<string> tv2talk_lines = new List<string> {
        "Hola " + player_username,
        "Estoy aqui para platicar?",
        "bla bla bla",
    };
    public static List<string> bookDescription = new List<string> {
        "You've picked up a book",
        "neat!",
    };

    public static Dictionary <string, List<string>> dialoguesDictionary = new Dictionary<string, List<string>> {
        {"tv", tv_init_lines},
        {"talk2tv", tv2talk_lines},
        {"book", bookDescription},
    };


}


