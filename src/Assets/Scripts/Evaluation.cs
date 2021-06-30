using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evaluation : MonoBehaviour
{
    float x = 1.0f;

    void Update()
    {
        StartCoroutine("LoadEval");
        if(Input.GetMouseButtonDown(0))
        {
            x = 0;
        }
    }

    IEnumerator LoadEval()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(x);

        this.transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(x+1.5f);

        this.transform.GetChild(2).gameObject.SetActive(true);
        this.transform.GetChild(2).gameObject.GetComponent<Text>().text = ScoreScript.finalScore.ToString();

        yield return new WaitForSeconds(x);

        this.transform.GetChild(3).gameObject.SetActive(true);

        yield return new WaitForSeconds(x+1.5f);

        this.transform.GetChild(4).gameObject.SetActive(true);
        this.transform.GetChild(4).gameObject.GetComponent<Text>().text = ScoreScript.maxCombo.ToString();

        yield return new WaitForSeconds(x);

        this.transform.GetChild(5).gameObject.SetActive(true);

        yield return new WaitForSeconds(x+1.5f);

        this.transform.GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(6).gameObject.GetComponent<Text>().text = ScoreScript.finalGrade;

        yield return new WaitForSeconds(x);

        if (SaveData.newHighScore)
        {
            this.transform.GetChild(7).gameObject.SetActive(true);
        }
        else
        {
            GameState.DontSave();
        } 
    }
}
