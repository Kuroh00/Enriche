using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using TMPro;

public class records : SaveData
{
    int[] _highScores = new int[5];
    string[] _playerNames = new string[5];
    Text[] scores = new Text[5];
    TextMeshProUGUI[] names = new TextMeshProUGUI[5];
    public BinaryFormatter bf = new BinaryFormatter();
    public FileStream file;
    int a = 0;

    playerData data;

    void Awake()
    {

        readFile();

        for (int y = 0; y < scores.Length + names.Length; y++)
        {
            if (y % 2 == 0)
            {
                names[y - a] = this.transform.GetChild(y).GetComponent<TextMeshProUGUI>();
                a++;
            }
            else
            {
                scores[y - a] = this.transform.GetChild(y).GetComponent<Text>();
                Debug.Log(y - a);
            }
        }
    }

    void Start()
    {
        for (int z = 0; z < scores.Length; z++)
        {
            names[z].text = _playerNames[z];
            if (_highScores[z] != 0)
            {
                scores[z].text = _highScores[z].ToString();
            }
            else scores[z].text = "--";
        }
    }

    public void readFile()
    {
        for (int x = 0; x < _highScores.Length; x++)
        {
            if (File.Exists(Application.persistentDataPath + "/save" + x.ToString() + ".dat"))
            {
                file = new FileStream(Application.persistentDataPath + "/save" + x.ToString() + ".dat", FileMode.Open);
                data = bf.Deserialize(file) as playerData;
                file.Close();
                _highScores[x] = data._score;
                _playerNames[x] = data.playerName;
            }
            else
            {
                _highScores[x] = 0;
                _playerNames[x] = "--";
            }
        }
        _highScores[4] = 0;
    }
}
    