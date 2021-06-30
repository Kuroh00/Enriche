using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Linq;
using TMPro;

public class ClickableScript : MonoBehaviour
{
    public static GameObject clickables;
    public static GameObject clickables1;
    public static GameObject clickables2;
    public static GameObject clickables3;
    public static BoxCollider box;
    public GameObject obj;
    static GameObject[] chObj = new GameObject[4];
    static TextMeshProUGUI[] choices = new TextMeshProUGUI[4];
    static int count = 0;
    static string[] temp = new string[4];
    static string answer;

    void Awake()
    {
        clickables = obj.transform.GetChild(0).gameObject;
        clickables1 = obj.transform.GetChild(1).gameObject;
        clickables2 = obj.transform.GetChild(2).gameObject;
        clickables3 = obj.transform.GetChild(3).gameObject;
        chObj = GameObject.FindGameObjectsWithTag("Choices");
        for (int x = 0; x < 4; x++)
        {
            choices[x] = chObj[x].GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
            temp[x] = " ";
        }
    }

    public static void Choices(int a, int b)
    {
        if(a == 1)
        {
            List<string> ans = new List<string>();
            ans.AddRange(QuestionScript.questions[b].choices);
            for (count = temp.Length; count >= 1; count--)
            {
                int x = Random.Range(0, count);
                temp[count - 1] = ans[x];
                ans.RemoveAt(x);
            }
            for (int z = 0; z < choices.Length; z++)
            {
                choices[z].text = temp[z].Replace("\\n", "\n");
            }
            answer = ans[0] ;
        }
    }

    public static void clearChoices()
    {
        for (int z = 0; z < choices.Length; z++)
        {
            choices[z].text = "";
        }
    }

    public static void CheckAnswer(int a, int b, float c)
    {
        if (answer.Contains(temp[b]))
        {
            sfxPlayer.rightAnswer();
            ScoreScript.UpdateScore(20, c);
            if (b == 0)
            {
                powerUps._upsChance(clickables.transform.position);
            }
            else if (b == 1)
            {
                powerUps._upsChance(clickables1.transform.position);
            }
            else if (b == 2)
            {
                powerUps._upsChance(clickables2.transform.position);
            }
            else if (b == 3)
            {
                powerUps._upsChance(clickables3.transform.position);
            }
        }
        else
        {
            sfxPlayer.wrongAnswer();
            ScoreScript.combo = 0;
            LifeScript.hearts[GamePlay.heartIndex].SetActive(false);
            GamePlay.heartIndex -= 1;
        }
    }

}
