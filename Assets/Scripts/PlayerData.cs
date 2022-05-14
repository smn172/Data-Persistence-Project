using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public static PlayerData istance;

    public string playerName;
    public int playerScore;
    public int bestPlayerScore;
    public string bestScore;

    private void Awake()
    {
        if (istance == null)
        {
            istance = this;
        }
        else if (istance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class BestPlayerData
        {
        public string bestPlayerName;
        public int bestPlayerScore;
        public string bestScore;
        }


    public void SaveData() 
    {
        BestPlayerData data = new BestPlayerData();
        data.bestPlayerName = playerName;
        data.bestPlayerScore = playerScore;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        Debug.Log(Application.persistentDataPath + "/savefile.json");
        Debug.Log(json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlayerData data = JsonUtility.FromJson<BestPlayerData>(json);

            playerName = data.bestPlayerName;
            bestPlayerScore = data.bestPlayerScore;
            bestScore = data.bestScore;
            Debug.Log("DATI CARICATI: " + playerName + " " + playerScore + " " + bestScore);
        }
        else
        {
            bestScore = "Best Score : none : 0 ";
            playerName = "";
        }
    }
}
