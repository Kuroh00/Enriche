using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GamePlay : MonoBehaviour
{
    public GameObject questionField;
    public GameObject healthBar;
    public GameObject clickables;
    public static int score = 0;
    public static int a = 100;
    float initialCD = 3.0f;
    int z = 0;
    int i = 0;
    Text cd;
    Vector3 worldPosition;
    Vector3 mousePos;
    public static int heartIndex;
    public static int quesIndex;
    int[] usedQuestions;
    int uqIndex = 0;
    Ray ray;
    RaycastHit hit;
    float healthTimer = 15.0f;
    bool isPlaying = true;

 void Awake()
    {
        heartIndex = 3;
        quesIndex = 0;
        score = 0;
        usedQuestions = new int[15];
        for (int x = 0; x < usedQuestions.Length; x++)
        {
            usedQuestions[x] = 999;
        }
        isPlaying = true;
    }

    void Update()
    {
        if (heartIndex < 0 && isPlaying)
        {
            a = 100;
            ScoreScript.SaveScore();
            GameState.GameOver();
            isPlaying = false;
        }

        if (initialCD > 0 && z == 0 && QuestionScript.questions.Length > 0)
        {
            initialCountDown.cd.text = " " + Mathf.Round(initialCD) + " ";
            initialCD -= Time.deltaTime;
        }
        else if (initialCD <= 0 && z == 0)
        {
            initialCountDown.cd.text = "";
            this.transform.GetChild(0).gameObject.SetActive(true);
            quesIndex = Random.Range(0, 20);
            usedQuestions[uqIndex] = quesIndex;
            QuestionScript.Questions(quesIndex);
            uqIndex++;
            z = 1;
            a = 0;
        }

        else if (initialCD <= 0 && a == 0)
        {
            if (!questionField.activeSelf)
            {
                questionField.SetActive(true);
            }

            a = 1;
        }

        else if (a == 1)
        {
            if (!healthBar.activeSelf)
            {
                healthBar.SetActive(true);
                healthBar.gameObject.GetComponent<Animation>().enabled = true;
            }
            if (!clickables.activeSelf)
            {
                clickables.SetActive(true);
            }
            else if (clickables.activeSelf)
            {
                ClickableScript.Choices(a, quesIndex);
                a = 2;
                healthBar.gameObject.GetComponent<Animation>().Play();
                sfxPlayer.countDown();
            }
        }

        if (a == 2)
        {
            healthTimer -= Time.deltaTime;

            if (healthTimer <= 0)
            {
                a = 100;
                QuestionScript.clearQuestion();
                ClickableScript.clearChoices();
                clickables.SetActive(false);
                LifeScript.hearts[heartIndex].GetComponent<Renderer>().enabled = false;
                StartCoroutine("timeOut");
            }

            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Input.mousePosition;
                ray = Camera.main.ScreenPointToRay(mousePos);

                if (ClickableScript.clickables.GetComponent<BoxCollider>().Raycast(ray, out hit, Mathf.Infinity))
                {
                    ClickableScript.clearChoices();
                    QuestionScript.clearQuestion();
                    CharaScript.spriteIndex = 0;
                    CharaScript.charaPosNew = ClickableScript.clickables.transform.position;
                    a = 3;
                    i = 0;
                    clickables.SetActive(false);
                    healthBar.gameObject.GetComponent<Animation>().enabled = false;
                    sfxPlayer.countDownStop();
                }
                else if (ClickableScript.clickables1.GetComponent<BoxCollider>().Raycast(ray, out hit, Mathf.Infinity))
                {
                    ClickableScript.clearChoices();
                    QuestionScript.clearQuestion();
                    CharaScript.spriteIndex = 1;
                    CharaScript.charaPosNew = ClickableScript.clickables1.transform.position;
                    a = 3;
                    i = 1;
                    clickables.SetActive(false);
                    healthBar.gameObject.GetComponent<Animation>().enabled = false;
                    sfxPlayer.countDownStop();
                }
                else if (ClickableScript.clickables2.GetComponent<BoxCollider>().Raycast(ray, out hit, Mathf.Infinity))
                {
                    ClickableScript.clearChoices();
                    QuestionScript.clearQuestion();
                    CharaScript.spriteIndex = 2;
                    CharaScript.charaPosNew = ClickableScript.clickables2.transform.position;
                    a = 3;
                    i = 2;
                    clickables.SetActive(false);
                    healthBar.gameObject.GetComponent<Animation>().enabled = false;
                    sfxPlayer.countDownStop();
                }
                else if (ClickableScript.clickables3.GetComponent<BoxCollider>().Raycast(ray, out hit, Mathf.Infinity))
                {
                    ClickableScript.clearChoices();
                    QuestionScript.clearQuestion();
                    CharaScript.spriteIndex = 3;
                    CharaScript.charaPosNew = ClickableScript.clickables3.transform.position;
                    a = 3;
                    i = 3;
                    clickables.SetActive(false);
                    healthBar.gameObject.GetComponent<Animation>().enabled = false;
                    sfxPlayer.countDownStop();
                }
            }
        }

        if(a == 3)
        {
            healthBar.SetActive(false);
            ClickableScript.CheckAnswer(quesIndex, i, healthTimer);
            a = 4;
        }

        if(a == 5)
        {
            healthTimer = 15.0f;
            if (IsArrayFilled() == false && isPlaying)
            {
                a = 100;
                isPlaying = false;

                if((SceneManager.GetActiveScene().buildIndex) < 4)
                {
                    GameState.nextStage();
                }
                else
                {
                    GameState.GameOver();
                    ScoreScript.SaveScore();
                }
            }
            else if (IsArrayFilled())
            {
                while (IsArrayFilled() && Array.Exists(usedQuestions, element => element == quesIndex))
                {
                    quesIndex = Random.Range(0, 20);
                }

                QuestionScript.Questions(quesIndex);
                usedQuestions[uqIndex] = quesIndex;
                uqIndex++;
                a = 0;
            }
        }
    }

    public bool IsArrayFilled()
    {
        if (uqIndex < 10)
        {
            return true;
        }
        else
            return false;
    }

    IEnumerator timeOut()
    {
        yield return new WaitForSeconds(2);

        healthTimer = 15.0f;
        heartIndex -= 1;
        while (IsArrayFilled() && Array.Exists(usedQuestions, element => element == quesIndex))
        {
            quesIndex = Random.Range(0, 20);
        }

        QuestionScript.Questions(quesIndex);
        usedQuestions[uqIndex] = quesIndex;
        uqIndex++;
        a = 0;
    }
}
