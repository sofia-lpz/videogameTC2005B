using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueName : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent.text = stateNameController.enemy_name;
    }
}
