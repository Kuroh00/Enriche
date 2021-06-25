using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestionScript : MonoBehaviour
{

    static TextMeshProUGUI question;
    public static Questions[] questions;

    void Awake()
    {
        question = GetComponent<TextMeshProUGUI>();
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("English");
            questions = Resources.LoadAll("English", typeof(Questions)).Cast<Questions>().ToArray();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            questions = Resources.LoadAll("Math", typeof(Questions)).Cast<Questions>().ToArray();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            questions = Resources.LoadAll("Trivia", typeof(Questions)).Cast<Questions>().ToArray();
        }
    }

    public static void Questions(int a)
    {
        question.text = questions[a].question.Replace("\\n", "\n");
        question.fontSize = questions[a].fontSize;
        question.lineSpacing = questions[a].lineSpacing;
    }

    public static void clearQuestion()
    {
        question.text = "";
    }
}
