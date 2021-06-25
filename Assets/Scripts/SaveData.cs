using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    int scoreToSave;
    int highScorePos;
    string Player;
    public static GameObject inputField;
    static int[] highScores = new int[5];
    static string[] playerNames = new string[5];
    public static bool newHighScore;
    int newHighScoreIndex;
    BinaryFormatter bf = new BinaryFormatter();

    [Serializable]
    public class playerData
    {
        public int _score;
        public string playerName;
    }

    void Awake()
    {
        newHighScore = false;

        fileCheck();

        for (int x = 0; x < highScores.Length; x++)
        {
            if (File.Exists(Application.persistentDataPath + "/save" + x.ToString() + ".dat"))
            {
                FileStream file = File.Open(Application.persistentDataPath + "/save" + x.ToString() + ".dat", FileMode.Open);
                playerData data = (playerData)bf.Deserialize(file);
                file.Close();
                highScores[x] = data._score;
                playerNames[x] = data.playerName;
            }
            else
            {
                highScores[x] = 0;
                playerNames[x] = "--";
            }
        }
    }

    void Start()
    {
        scoreToSave = ScoreScript.finalScore;
        for (int y = highScores.Length - 1; y > -1; y--)
        {
            Debug.Log("High Score " + y + " = " + highScores[y]);
            if(scoreToSave > highScores[y])
            {
                int temp = highScores[y];
                string tempS = playerNames[y];
                highScores[y] = scoreToSave;
                if(y < highScores.Length - 1)
                {
                    highScores[y + 1] = temp;
                    playerNames[y + 1] = tempS;
                }
                newHighScore = true;
                newHighScoreIndex = y;
            }
        }
    }

    public void saveData()
    {
        inputField = GameObject.Find("NameInput");
        Player = inputField.transform.GetChild(1).gameObject.GetComponent<Text>().text;

        for (int z = highScores.Length - 1; z > -1; z--) 
        {
            if(z == newHighScoreIndex)
            {
                FileStream file = File.Create(Application.persistentDataPath + "/save" + newHighScoreIndex.ToString() + ".dat");
                playerData data = new playerData();
                data._score = scoreToSave;
                data.playerName = Player;
                bf.Serialize(file, data);
                file.Close();
            }
            else if(z != newHighScoreIndex)
            {
                FileStream file = File.Create(Application.persistentDataPath + "/save" + z.ToString() + ".dat");
                playerData data = new playerData();
                data._score = highScores[z];
                data.playerName = playerNames[z];
                bf.Serialize(file, data);
                file.Close();
            }
        }
        
        GameState.Saved();
    }

    public void fileCheck()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            if (!File.Exists(Application.persistentDataPath + "/save" + x.ToString() + ".dat"))
            {
                highScores[x] = 0;
                playerNames[x] = "--";
            }
        }
    }
}
