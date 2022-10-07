using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    //Information that needs to persist between scenes
    public string playerName;
    public string highScoreName;
    public int score;

    //Information that needs to persist between application runs.
    public int highScore;
    public MainManager mainManager;

    private void Awake()
    {
        if (score >= highScore)
        {
            score = highScore;
        }
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
        public string highScoreName;
        public int score;
        public int highScore;
    }
    //Writes the information to the JSON
    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.score = score;
        data.highScoreName = highScoreName;
        data.highScore = highScore;
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
            highScore = data.highScore;
            score = data.score;
            highScoreName = data.highScoreName;
        }
    }
}
