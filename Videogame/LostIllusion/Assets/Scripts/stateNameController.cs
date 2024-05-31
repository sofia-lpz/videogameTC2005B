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
    /*PLAYER INFO*/
    public static Player player = new Player();

    public static string player_username = player.username;
    public static int player_level = player.level;
    public static int player_matches_won = player.matches_won;
    public static int player_status = player.status;

    public static List<string> inventory = new List<string>();

    /*FOR GAMEPLAY*/
    public static bool gamePaused = false;
    public static bool freezePlayer = false;

    public static float playerXPosInScene = 0;
    public static float playerYPosInScene = 0;
    public static string playerPreviousScene;

    /*FOR AUDIO*/
    public static float volume = 0.5f;
    public static bool muted = false;
    public static float storedVolume = 0;

    /*LIST OF SCENES*/
    public static List<string> scenes = new List<string> {
        "tutorial_map",
        "intro",
        "Outside"
        };
    
    /*MATCH RESULTS*/
    public static int match_tv = 0; //set to 1 if the tv match has been won, -1 if lost, 0 if never played
}


