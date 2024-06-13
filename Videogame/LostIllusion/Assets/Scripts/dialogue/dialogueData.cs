/*
File to hold dialogue across scenes

Sofia Moreno
13/5/2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueData : stateNameController
{

/*COLOMETA LINES*/
public static List<string> colometa_lines_1 = new List<string> {
    "3... 2... 1...",
    "Ah!",
    "Now young woman, tell the audience...",
    "...Do you feel hypnotized?"
};

public static List<string> colometa_lines_2 = new List<string> {
    "Ah... are you so sure?"
};

public static List<string> colometa_lines_3 = new List<string> {
    stateNameController.player_username,
    "If I asked you to open your eyes, you wouldn't be able to...",
    "Don't make the effort, it's not worth it",
    "It's not worth it..."
};

public static List<string> colometa_lines_4 = new List<string> {
    "How about you little girl?",
    "I reckon you'll have much more fun.",
    "Go on, don't be shy, tell the audience!",
    "Do you feel hypnotized?"
};

public static List<string> colometa_lines_5 = new List<string> {
    "Focus on an image now",
    "A real or imagined one",
    "Focus on every single detail you hadn't noticed before",
    "A safe place, a place you love, somewhere you want to be"
};

public static List<string> colometa_lines_6 = new List<string> {
    "Do you see it?"
};

public static List<string> colometa_lines_7 = new List<string> {
    "And sleep...",
    "Sleep..."
};

public static List<string> colometa_lines_8 = new List<string> {
    "Do you not want an adventure?",
    "Do you not want to be a hero?",
    "Is that not why you came?"
};

public static List<string> colometa_lines_9 = new List<string> {
    "Is this not what we all want?!",
    "To be taken away from this town for a while?!",
    "Come on, last count!",
    "3...!",
    "2...!"
};

public static List<List<string>> colometa_lines = new List<List<string>> {
    colometa_lines_1,
    colometa_lines_2,
    colometa_lines_3,
    colometa_lines_4,
    colometa_lines_5,
    colometa_lines_6,
    colometa_lines_7,
    colometa_lines_8,
    colometa_lines_9
};
/*COLOMETA LINES END*/

/*NARRATOR LINES*/
public static List<string> narrator_lines_1 = new List<string> {
    "3... 2... 1...",
    "And a hundred times more.",
    "3... 2... 1...",
};

public static List<string> narrator_lines_2 = new List<string> {
    "You feel the clammy hand of the magician on your shoulder",
    "The heat of the spotlight",
    "You see nothing, your eyes still closed...",
    "<<Not really>>, you say"
};

public static List<string> narrator_lines_3 = new List<string> {
    "Your eyes open suddenly",
    "What a terrible show...",
    "Don't magicians snap their fingers to wake people up?",
    "Are you even awake?"
};

public static List<string> narrator_lines_4 = new List<string> {
    "3... 2... 1...",
    "And a thousand times more.",
    "3... 2... 1...",
};

public static List<string> narrator_lines_5 = new List<string> {
    "Breathe in...",
    "And breathe out...",
};

public static List<string> narrator_lines_6 = new List<string> {
    "The hand leaves your shoulder",
    "You feel the magician walk to the girl sat beside you"
};

public static List<string> narrator_lines_7 = new List<string> {
    "3... 2... 1...",
    "And a million times more.",
    "3... 2... 1...",
};

public static List<string> narrator_lines_8 = new List<string> {
    "You think you'll imagine your mother's house... you miss it",
    "Maybe some big city, like the ones you've always wanted to move to.",
    "You don't.",
    "You imagine yourself, right here"
};

public static List<string> narrator_lines_9 = new List<string> {
    "3... 2... 1...",
    "And a billion times more.",
    "3... 2... 1...",
    "It's almost over."
}; 

public static List<string> narrator_lines_10 = new List<string> {
    "You don't want to.",
    "You want to get off the stage, you want to go home",
    "Colometa notices, leans in to whisper"
};

public static List<string> narrator_lines_11 = new List<string> {
    "He turns back to the audience",
    "They're flabbergasted",
    "Something's happened"
};

public static List<string> narrator_lines_12 = new List<string> {
    "1!"
};

public static List<List<string>> narrator_lines = new List<List<string>> {
    narrator_lines_1,
    narrator_lines_2,
    narrator_lines_3,
    narrator_lines_4,
    narrator_lines_5,
    narrator_lines_6,
    narrator_lines_7,
    narrator_lines_8,
    narrator_lines_9,
    narrator_lines_10,
    narrator_lines_11,
    narrator_lines_12
};
/*NARRATOR LINES END*/

/*WOMAN LINES START*/

public static List<string> woman_lines_1 = new List<string> {
    player_username + "!",
    "HAVE YOU SEEN MY DAUGHTER?",
    "She never came back from the magic show",
    "You-You were there, have you seen her?!",
    "PLEASE HELP ME FIND HER"
};

public static List<string> woman_lines_2 = new List<string> {
    "Have you found her?",
    "I'm so worried",
    "Please keep looking!"
};

public static List<List<string>> woman_lines = new List<List<string>> {
    woman_lines_1,
    woman_lines_2
};


public static List<List<string>> cutsceneStart_lines = new List<List<string>> {
    new List<string> { "A memory..." }
};

/*Adrian lines*/
public static List<string> adrian_lines_1 = new List<string> {
    "AH! " + player_username,
    "There's a...! We have to go!",
    "What?",
    "I'm not hallucinating!",
    "This is not a game!",
    "Fine, do whatever you like! I'm leaving!"
};

public static List<List<string>> adrian_lines = new List<List<string>> {
    adrian_lines_1
};

/*girl lines*/
public static List<string> girl_lines_1 = new List<string> {
    "WRAAAAH!",
    "...",
    "Do you...?",
    "Can you see me now?",
    "...",
    "No, don't worry, I'm not hurt",
    "I'm just...",
    "I sort of liked it",
    "Being a monster",
    "I don't think I'm a monster",
    "Well, it doesn't matter",
    "But... I can't stay here",
    "Good luck, " + player_username
};

public static List<List<string>> girl_lines = new List<List<string>> {
    girl_lines_1
};

/*motherEvent comment lines*/
public static List<string> motherEvent_lines_1 = new List<string> {
    "Is that woman hypnotized? That was odd",
    "You better look for the girl"
};

public static List<List<string>> motherEvent_lines = new List<List<string>> {
    motherEvent_lines_1
};

/*runningEvent comment lines*/
public static List<string> runningEvent_lines_1 = new List<string> {
    "He came from the forest over there"
};

public static List<string> runningEvent_lines_2 = new List<string> {
    "Maybe you should keep looking for clues out here"
};

public static List<string> runningEvent_lines_3 = new List<string> {
    "It's probably nothing... but",
    "Maybe there's someone that needs help out there"
};

public static List<List<string>> runningEvent_lines = new List<List<string>> {
    runningEvent_lines_1,
    runningEvent_lines_2,
    runningEvent_lines_3
};


// to do, make a dictionary of dictionaries instead of dictionary of lists
public static Dictionary<string, List<List<string>>> dialoguesDictionary = new Dictionary<string, List<List<string>>> {
    {"COLOMETA", colometa_lines},
    {"NARRATOR", narrator_lines},
    {"WOMAN", woman_lines},
    {"cutsceneStart", cutsceneStart_lines},
    {"ADRIAN", adrian_lines},
    {"GIRL", girl_lines},
    {"motherEvent", motherEvent_lines},
    {"runningEvent", runningEvent_lines}
};

public static List<string> scaryLines = new List<string> {
"Are you even awake?",
"Do you see it?",
    "Do you not want an adventure?",
    "Do you not want to be a hero?",
    "Is that not why you came?"
};

}
