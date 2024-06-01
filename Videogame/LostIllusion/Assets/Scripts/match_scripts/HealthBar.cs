/*
HealthBar.cs

This script is responsible for managing the health bars in the game. 
It includes a Slider object, which is used to represent the health bar. 
The SetMaxHealth method is used to set the maximum value of the slider to the character's maximum health and set the current value of the slider to the character's current health. 
The SetHealth method is used to set the current value of the slider to the character's current health. 
This script is attached to a game object that represents a character's health bar, and is used to update the health bar as the character's health changes.

Luis Filorio
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
