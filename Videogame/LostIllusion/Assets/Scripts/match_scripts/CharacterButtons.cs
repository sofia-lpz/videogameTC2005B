using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtons : MonoBehaviour
{
    public static CharacterButtons currentButton;
    [SerializeField] Color normalColor;
    [SerializeField] Color highlightColor = Color.yellow;
    [SerializeField] float initialPos;
    [SerializeField] float activePos;
    private int energyCost = 1;
    private bool firstClick = true;

    // Start is called before the first frame update
    void Start()
    {
        normalColor = GetComponent<Image>().color;  
    }

    public void Highlight()
    {
        if (TCG_Controller.instance.currentTurn == TCG_Controller.Turn.Enemy)
        {
            return;
        }

        if (TCG_Controller.instance.energy < energyCost && !firstClick)
        {
            TCG_Controller.instance.notEnoughEnergyText.text = "Not enough energy";
            return;
        }

        if (GetComponent<Image>().color != highlightColor && TCG_Controller.instance.energy >= energyCost)
        {
            if (!firstClick) {
                TCG_Controller.instance.energy -= energyCost;
                TCG_Controller.instance.EnergyText.text = "Energy: " + TCG_Controller.instance.energy.ToString();
            }    
        } else {
            firstClick = false;
        }
        
        if (currentButton != null)
        {
            currentButton.GetComponent<Image>().color = currentButton.normalColor;
            currentButton.transform.position = new Vector3(currentButton.transform.position.x, currentButton.initialPos, currentButton.transform.position.z);
        }

        currentButton = this;
        initialPos = transform.position.y;
        activePos = initialPos + 15f;
        GetComponent<Image>().color = highlightColor;
        transform.position = new Vector3(transform.position.x, activePos, transform.position.z);
    }
}
