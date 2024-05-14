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
    /*LIST OF SCENES*/
    public static List<string> scenes = new List<string> {
        "Instructions",
        "cutscene0",
        "Home",
        "Outside"
        };
    
    public static bool gamePaused = false;

/*MATCH RESULTS*/
    public static int match_tv = 0; //set to 1 if the tv match has been won, -1 if lost, 0 if never played
/*MATCH RESULTS END*/

    public static string player_username = "nombre de usuario";
    public static int player_level = 0;
    public static List<string> inventory = new List<string>();
    
 

}


