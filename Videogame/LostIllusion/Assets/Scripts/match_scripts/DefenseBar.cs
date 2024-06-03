/*
DefenseBar.cs

This script is responsible for managing the defense bars in the game. 
It includes a Slider object, which is used to represent the defense bar. 
The SetMaxDefense method is used to set the maximum value of the slider to the character's maximum defense and set the current value of the slider to the character's current defense. 
The SetDefense method is used to set the current value of the slider to the character's current defense. 
This script is attached to a game object that represents a character's defense bar, and is used to update the defense bar as the character's defense changes.

Luis Filorio
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxDefense(int defense)
    {
        slider.maxValue = defense;
        slider.value = defense;
    }

    public void SetDefense(int defense)
    {
        slider.value = defense;
    }
}