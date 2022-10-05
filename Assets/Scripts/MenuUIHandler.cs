using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class MenuUIHandler : MonoBehaviour
{
    public string enterName;
    public GameObject inputField;

    //Loads the game when the start button is clicked as well as all the stored player info
    public void StartGame()
    {
        PlayerData.Instance.LoadPlayerData();
        SceneManager.LoadScene(1);
    }
    public void EnterName()
    {
        enterName = inputField.GetComponent<Text>().text;
        PlayerData.Instance.playerName = enterName;
        PlayerData.Instance.SavePlayerData();
    }
}
