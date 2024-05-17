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

public static List<List<string>> colometa_lines = new List<List<string>> {
    colometa_lines_1
};
/*COLMETA LINES END*/


// to do, make a dictionary of dictionaries instead of dictionary of lists
public static Dictionary<string, List<List<string>>> dialoguesDictionary = new Dictionary<string, List<List<string>>> {
    {"tv", tv_lines},
    {"talk2tv", new List<List<string>> { tv2talk_lines }},
    {"book", new List<List<string>> { bookDescription }},
    {"COLOMETA", colometa_lines}
};

}
