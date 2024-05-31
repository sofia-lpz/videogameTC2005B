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
/*TV LINES*/
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

        public static List<List<string>> tv_lines = new List<List<string>> {
    tv_lines_1,
    tv_lines_won,
    tv_lines_lost
};
/*TV LINES END*/

/*TV2TALK LINES*/
    public static List<string> tv2talk_lines = new List<string> {
        "Hola " + player_username,
        "Estoy aqui para platicar en el index 0",
        "bla bla bla",
    };
/*TV2TALK LINES END*/

/*BOOK DESCRIPTION*/
    public static List<string> bookDescription = new List<string> {
        "You've picked up a book",
        "neat!",
    };
/*BOOK DESCRIPTION END*/


/*COLMETA LINES*/
public static List<string> colometa_lines_1 = new List<string> {
    "3... 2... 1...",
    "ah!",
    "Now Adria, tell me...",
    "...Do you feel hypnotized?"
};

public static List<string> colometa_lines_2 = new List<string> {
    "Ah... are you so sure?"
};

public static List<List<string>> colometa_lines = new List<List<string>> {
    colometa_lines_1,
    colometa_lines_2
};
/*COLMETA LINES END*/

/*NARRATOR LINES*/
public static List<string> narrator_lines_1 = new List<string> {
    "3... 2... 1...",
    "and a million times more.",
    "3... 2... 1..."
};

public static List<string> narrator_lines_2 = new List<string> {
    "Your eyes open, you're awake suddenly",
    "Don't magicians snap their fingers to wake people up?",
    "won't you wake up?"
};

public static List<string> narrator_lines_3 = new List<string> {
    "You feel the clammy hand of the magician on your shoulder",
    "you feel the heat of the spotlight",
    "not much more.",
    "Not really, you say"
};

public static List<List<string>> narrator_lines = new List<List<string>> {
    narrator_lines_1,
    narrator_lines_2,
    narrator_lines_3
};
/*NARRATOR LINES END*/

/*WOMAN LINES START*/

public static List<string> woman_lines_1 = new List<string> {
    player_username.ToUpper() + "!",
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


/*dev_bunny dialogue start*/
public static List<string> dev_bunny_lines_1 = new List<string> {
    "Hello " + player_username,
    "I'm the dev bunny",
    "I'm here to help you",
    tcgData.Cards.Count > 0 ? "The first card name is " + tcgData.Cards[0].name : "There are no cards available"
};


// to do, make a dictionary of dictionaries instead of dictionary of lists
public static Dictionary<string, List<List<string>>> dialoguesDictionary = new Dictionary<string, List<List<string>>> {
    {"tv", tv_lines},
    {"talk2tv", new List<List<string>> { tv2talk_lines }},
    {"book", new List<List<string>> { bookDescription }},
    {"COLOMETA", colometa_lines},
    {"dev_bunny", new List<List<string>> { dev_bunny_lines_1 }},
    {"NARRATOR", narrator_lines},
    {"WOMAN", woman_lines}

};

public static List<string> scaryLines = new List<string> {
"won't you wake up?"
};

};