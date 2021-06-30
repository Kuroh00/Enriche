using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue;
    public static int addScore;
    public static float combo = 0;
    public static int maxCombo = 0;
    public static Text score;
    public static int finalScore;
    public static Text _addScore;
    static float x;
    public static string finalGrade;

    void Start()
    {
        score = this.transform.GetChild(0).GetComponent<Text>();
        _addScore = this.transform.GetChild(1).GetComponent<Text>();
        if(scoreValue != 0)
        {
            score.text = scoreValue.ToString();
        }

    }

    public static void UpdateScore(int a, float b)
    {
        addScore = (int)(a * Mathf.Pow(1.1f, combo) * (1+(b * 0.01f)));
        scoreValue = scoreValue + addScore;
        combo++;
        if(Mathf.Floor(combo) > maxCombo)
        {
            maxCombo = (int)Mathf.Floor(combo);
        }
        score.text = scoreValue.ToString();
    }

    public static void bonusScore(int a)
    {
        scoreValue = scoreValue + a;
        score.text = scoreValue.ToString();
    }

    public static void SaveScore()
    {
        finalScore = scoreValue;
        scoreValue = 0;
        combo = 0;
        x = (finalScore / 38);
        Debug.Log(x);
        if (x >= 90)
        {
            finalGrade = "SS";
        }
        else if (x >= 80 && x < 90)
        {
            finalGrade = "S+";
        }
        else if (x >= 70 && x < 80)
        {
            finalGrade = "S";
        }
        else if (x >= 60 && x < 70)
        {
            finalGrade = "A";
        }
        else if (x >= 40 && x < 50)
        {
            finalGrade = "B";
        }
        else if (x >= 30 && x < 40)
        {
            finalGrade = "C";
        }
        else if (x >= 20 && x < 30)
        {
            finalGrade = "D";
        }
        else if (x >= 10 && x < 20)
        {
            finalGrade = "E";
        }
        else if (x < 10)
        {
            finalGrade = "F";
        }
    }

    public static void ResetScore()
    {
        scoreValue = 0;
        combo = 0;
    }
}
