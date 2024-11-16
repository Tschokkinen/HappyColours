using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int prevPoints;
}

public class Database : MonoBehaviour
{
    private GameData gameData = new GameData();
    string saveFilePath;

    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/savedata.json";
        Debug.Log("saveFilePath: " + saveFilePath);
    }

    public int ReadFile()
    {
        
        if (File.Exists(saveFilePath))
        {
            // Debug.Log("Reading");
            string loadContents = File.ReadAllText(saveFilePath);
            // Debug.Log("fileContents: " + fileContents);
            gameData = JsonUtility.FromJson<GameData>(loadContents);

            return gameData.prevPoints;
        }
        Debug.Log("No file");
        return 0;
    }

    public void WriteFile(int newPoints)
    {
        gameData.prevPoints = newPoints;
        // Debug.Log("Writing file: " + gameData.val);
        string saveContents = JsonUtility.ToJson(gameData);
        // Debug.Log("jsonString: " + jsonString);
        System.IO.File.WriteAllText(saveFilePath, saveContents);
    }
}


