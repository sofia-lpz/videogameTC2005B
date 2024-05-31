using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueCutsceneData : stateNameController
{



    public static Dictionary<string, List<List<string>>> dialoguesDictionary = new Dictionary<string, List<List<string>>> {
    { "intro", new List<List<string>> {
        new List<string> { "Narrator", "It was a quiet evening in the village of Gracia." },
        new List<string> { "Colometa", "The air is so still tonight, it feels almost eerie." },
        new List<string> { "Narrator", "Colometa stood by the window, gazing at the empty street." },
        new List<string> { "Colometa", "I wonder where everyone has gone. It's never this silent." },
        new List<string> { "Narrator", "The silence was broken by the distant sound of bells." },
        new List<string> { "Colometa", "Those bells... they only ring during an emergency." },
        new List<string> { "Narrator", "Her heart began to race as she listened intently." },
        new List<string> { "Colometa", "I need to find out what's happening. I can't just stay here." },
        new List<string> { "Narrator", "With determination, Colometa grabbed her coat and headed out." }
    }}};



};
