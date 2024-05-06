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


    /*LIST OF SCENES*/
    public static List<string> scenes = new List<string> {
        "Home",
        "Outside",
        };
    

/*MATCH RESULTS*/
    public static int match_tv = 0; //set to 1 if the tv match has been won, -1 if lost, 0 if never played
/*MATCH RESULTS END*/

    public static string player_username = "nombre de usuario";
    public static int player_level = 0;
    public static List<string> inventory = new List<string>();
    
    public static List<string> tv_lines_1 = new List<string> {
        "Hola " + player_username,
        "QUE?",
        "QUIERES UNA PELEA?",
        "TE DARE UNA PELEA",
    };

    public static List <string> tv_lines_won = new List<string> {
        "Me ganaste",
        "Felicidades",
        "ahora soy parte de tu inventario de teammates"
    };

    public static List <string> tv_lines_lost = new List<string> {
        "perdiste",
        "ve a buscar mas cartas en el mapa",
        "y vuelve a intentarlo"
    };
    public static List<string> tv2talk_lines = new List<string> {
        "Hola " + player_username,
        "Estoy aqui para platicar en el index 0",
        "bla bla bla",
    };
    public static List<string> bookDescription = new List<string> {
        "You've picked up a book",
        "neat!",
    };

    public static List<List<string>> tv_lines = new List<List<string>> {
    tv_lines_1,
    tv_lines_won,
    tv_lines_lost
};

public static Dictionary<string, List<List<string>>> dialoguesDictionary = new Dictionary<string, List<List<string>>> {
    {"tv", tv_lines},
    {"talk2tv", new List<List<string>> { tv2talk_lines }},
    {"book", new List<List<string>> { bookDescription }},
};


}


