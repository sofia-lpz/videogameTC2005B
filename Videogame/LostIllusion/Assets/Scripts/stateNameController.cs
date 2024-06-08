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
    public static List<Player> Players = new List<Player>();
    public static string playerStatus = "None";

    public static string player_username = "nombre de usuario";
    public static int player_level = 1;
    public static int player_matches_won = 1;

    public static List<string> inventory = new List<string>();

    /*FOR GAMEPLAY*/
    public static bool gamePaused = false;
    public static bool freezePlayer = false;

    public static float playerXPosInScene = 0;
    public static float playerYPosInScene = 0;
    public static string playerPreviousScene = "";

    public static HashSet<string> triggeredEvents = new HashSet<string>();
    public static HashSet<string> playedCutscenes = new HashSet<string>();
    public static HashSet<string> triggeredCharacters = new HashSet<string>();

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

    /*LIST OF SCARY SCENES*/
    public static HashSet<string> scaryScenes = new HashSet<string> {
        "COLOMETA"
        };
    
    /*MATCH RESULTS*/
    public static int match_CENTIPEDE = 0; //set to 1 if the tv match has been won, -1 if lost, 0 if never played
}


