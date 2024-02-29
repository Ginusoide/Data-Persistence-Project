using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RecordManager : MonoBehaviour
{ 
    public static RecordManager Instance; //MODELLO SINGLETON

    public string ActualPlayer;
    public string PlayerName;
    public int BestScore;

    private string scoreFilename = "/bestscore.json";

    private void Awake()
    {
        // MODELLO SINGLETON
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveActualScore(int score)
    {
        if (score > BestScore)
        {
            // Aggiorno dati nuovo miglior record
            BestScore = score;
            PlayerName = ActualPlayer;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int BestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + scoreFilename, json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + scoreFilename;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            BestScore = data.BestScore;
        }
    }
}
