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
            muteButtonText.text = "Unmute";
        }
        else{
            muteButtonText.text = "Mute";
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
            muteButtonText.text = "Mute";
        }
        else{
            stateNameController.storedVolume = stateNameController.volume;
            stateNameController.volume = 0;
            stateNameController.muted = true;
            slider.value = 0;
            volumeText.text = "0%";
            muteButtonText.text = "Unmute";
        }
    }

}
