using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveName : MonoBehaviour
{
    public static SaveName Instance;

    public string playerName;
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
        public int saveScore;
    }
    //Saves the score from MainManager and then passes it through the method below to save it to a json.
    public void SaveScore(int points)
    {
        SaveData data = new SaveData();
        data.saveScore = points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(points);
    }
    //Now load the json the next time the game is restarted. 
    public void LoadHighScore()
    {

    }
}
