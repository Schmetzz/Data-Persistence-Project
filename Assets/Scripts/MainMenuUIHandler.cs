using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void NewNameSelected(string name)
    {
        SaveName.Instance.playerName = name;
        Debug.Log(name);
    }
}
