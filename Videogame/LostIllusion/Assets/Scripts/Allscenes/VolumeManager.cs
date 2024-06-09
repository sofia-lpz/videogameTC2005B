/*
VolumeManager.cs

This script is responsible for managing the volume settings
It uses a slider to adjust the volume and displays the current volume percentage. 
The script also provides a mute button that toggles between muting and unmuting the game's audio. 
When the game is muted, the current volume level is stored so it can be restored when the game is unmuted. 
The volume level and mute status are stored in the stateNameController class and are persistent across scenes.

Sofia Moreno
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeManager : MonoBehaviour
{
[SerializeField] public Slider slider;
[SerializeField] public TextMeshProUGUI volumeText;
[SerializeField] public TextMeshProUGUI muteButtonText;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = stateNameController.volume;
        volumeText.text = (int)(stateNameController.volume * 100) + "%";
        if (stateNameController.muted){
            muteButtonText.text = "unmute";
        }
        else{
            muteButtonText.text = "mute";
        }
    }

    // Update is called once per frame
    void Update()
    {
        stateNameController.volume = slider.value;
        volumeText.text = (int)(stateNameController.volume * 100) + "%";
    }

    public void muteButton(){
        
        if (stateNameController.muted){
            stateNameController.muted = false;
            stateNameController.volume = stateNameController.storedVolume;
            slider.value = stateNameController.storedVolume;
            volumeText.text = (int)(stateNameController.volume * 100) + "%";
            muteButtonText.text = "mute";
        }
        else{
            stateNameController.storedVolume = stateNameController.volume;
            stateNameController.volume = 0;
            stateNameController.muted = true;
            slider.value = 0;
            volumeText.text = "0%";
            muteButtonText.text = "unmute";
        }
    }

}
