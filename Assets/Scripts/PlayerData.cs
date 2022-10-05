using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    //Information that needs to persist between scenes
    public string playerName;
    public int score;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
        public int highScore;
    }
    //Writes the information to the JSON
    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.score = score;
        data.highScore = highScore; 
        data.playerName = playerName;

        //Checks if there is a new highscore by comparing the score earned and then setting it to whichever is highest.
        if (data.score >= highScore)
        {
            score = highScore;
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //Loads the information from the JSON
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score = data.score;
            highScore = data.highScore;
            playerName = data.playerName;
        }
    }
}
