using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class characterSelection : MonoBehaviour
{
    [SerializeField] GameObject characterPrefab;
    [SerializeField] Transform characterParent;
    public int numCharacters = 6;
    [SerializeField] List<CharacterButtons> characterButtons;
    public Villager character;
    private int selectedCount;
    [SerializeField] Button startGameButton;

    // Start is called before the first frame update
    void Start()
    {
        PrepareCharacterSelection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrepareCharacterSelection()
    {
        for (int i = 0; i < numCharacters; i++)
        {
            GameObject newCharacter = Instantiate(characterPrefab, characterParent);
            DeactivateComponents(newCharacter);
            CharacterButtons charButton = newCharacter.GetComponent<CharacterButtons>();
            characterButtons.Add(charButton);
            charButton.Init(tcgData.Villagers[i]);
            Button buttonComponent = newCharacter.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => OnCharacterSelected(charButton));
        }
    }

     void DeactivateComponents(GameObject characterInstance)
    {
        Transform healthBar = characterInstance.transform.Find("HealthBar");
        Transform defenseBar = characterInstance.transform.Find("DefenseBar");
        Transform atkText = characterInstance.transform.Find("ATK");

        healthBar.gameObject.SetActive(false);
        defenseBar.gameObject.SetActive(false);
        atkText.gameObject.SetActive(false);
    }

    void OnCharacterSelected(CharacterButtons selectedCharacter)
    {
        if (selectedCount < 2)
        {
            tcgData.pickedCharacters.Add(selectedCharacter.character.villager_id);
            selectedCharacter.GetComponent<Button>().interactable = false;
            selectedCount++;
            Debug.Log(selectedCharacter.character.villager_id);
            Debug.Log(tcgData.pickedCharacters.Count);
            if(selectedCount == 2)
            {
                startGameButton.interactable = true;
            }
        } 
    }

    public void CharacterReset()
    {
        foreach (CharacterButtons character in characterButtons)
        {
            character.GetComponent<Button>().interactable = true;
        }
        tcgData.pickedCharacters.Clear();
        selectedCount = 0;
        startGameButton.interactable = false;
    }
}
