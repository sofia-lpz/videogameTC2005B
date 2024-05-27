using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneData : MonoBehaviour
{


public static List<string> colometa_lines_1 = new List<string> {
    "3... 2... 1...",
    "ah!",
    "Now young woman, tell me...",
    "Do you feel hypnotized?"
};

public static List<string> colometa_lines_2 = new List<string> {
    "ah...",
    "we'll see!"
};


public static List<string> narrator_lines_1 = new List<string> {
   "3... 2... 1...",
   "and a million times more " + stateNameController.player_username + " ...",
   "3... 2... 1..."
};

public static List<string> narrator_lines_2 = new List<string> {
    stateNameController.player_username + "'s eyes flutter open, awake suddenly",
    "Don't magicians snap their fingers to wake people up?"
};

public static List<string> narrator_lines_3 = new List<string> {
    stateNameController.player_username + " doesn't know how to answer.",
    "She feels the clammy hand of the magician on her shoulder,",
    "the heat of the spotlight on stage,",
    "Not much else."
};


public static List<List<string>> cutscene1 = new List<List<string>> {
    narrator_lines_1,
    colometa_lines_1,
    narrator_lines_2,
    narrator_lines_3
};


/*
public static Dictionary<string, List<List<string>>> cutsceneDictionary = new Dictionary<string, List<List<string>>>{
    {"COLOMETA", colometa_lines},
    {"NARRATOR", narrator_lines}
};
*/

}
