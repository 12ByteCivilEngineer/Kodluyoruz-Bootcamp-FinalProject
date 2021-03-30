using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterSelect : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] characterModels;

    public CharacterBuy[] characters;
    public Button buyButton;

    int coin = 1000;
    public TextMeshProUGUI proUGUI;

    private void Start()
    {
        foreach (CharacterBuy character in characters)
        {
            if (character.price==0)
            {
                character.inUnLocked = true;
            }
            else
            {
                character.inUnLocked = PlayerPrefs.GetInt(character.name, 0)==0 ? false : true;
            }
        }
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject character in characterModels)
        {
            character.SetActive(false);
            characterModels[currentCharacterIndex].SetActive(true);
        }
        //PlayerPrefs.DeleteAll();
    }
    private void Update()
    {
        UpdateUI();
        proUGUI.text = "" + coin;
    }
    public void ChangeNext()
    {
        characterModels[currentCharacterIndex].SetActive(false);
        currentCharacterIndex++;
        if (currentCharacterIndex==characterModels.Length)
        {
            currentCharacterIndex = 0;
        }
        characterModels[currentCharacterIndex].SetActive(true);
        CharacterBuy coinPrice = characters[currentCharacterIndex];
        if (!coinPrice.inUnLocked)
        {
            return;
        }
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
    }
    public void ChangePrevious()
    {
        characterModels[currentCharacterIndex].SetActive(false);
        currentCharacterIndex--;
        if (currentCharacterIndex == -1)
        {
            currentCharacterIndex = characterModels.Length-1;
        }
        characterModels[currentCharacterIndex].SetActive(true);

        CharacterBuy coinPrice = characters[currentCharacterIndex];
        if (!coinPrice.inUnLocked)
        {
            return;
        }
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
    }
    public void UnLockCharacter()
    {
        CharacterBuy coinPrice = characters[currentCharacterIndex];
        PlayerPrefs.SetInt(coinPrice.name, 1);
        PlayerPrefs.SetInt("SelectedCharacter",currentCharacterIndex);
        coinPrice.inUnLocked = true;
        //PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - coinPrice.price); >> Satın alınan öge fiyatı
        coin= coin - coinPrice.price;
    }
    public void UpdateUI()
    {
        CharacterBuy coinPrice = characters[currentCharacterIndex];
        if (coinPrice.inUnLocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<Text>().text = "Buy -" + coinPrice.price;
            
            //if (coinPrice.price<PlayerPrefs.GetInt("NumberOfCoins",0)) >> 
            if (coinPrice.price<coin)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }
}
