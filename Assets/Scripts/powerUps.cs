using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class powerUps : MonoBehaviour
{
    public static GameObject[] _ups;
    public static bool chanceGet;
    public static int bonus;
    public static GameObject ups;

    void Awake()
    {
        chanceGet = false;
        _ups = Resources.LoadAll("PowerUps", typeof(GameObject)).Cast<GameObject>().ToArray();
    }

    public static void _upsChance(Vector3 a)
    {
        int x = Random.Range(0, 10);

        if (x == 1 || x == 5)
        {
            chanceGet = true;
            int b = Random.Range(0, 10);

            if (b == 3)
            { 
                ups = Instantiate(_ups[1], a, Quaternion.identity);
                bonus = 1;
            }
            else
            {
                ups = Instantiate(_ups[0], a, Quaternion.identity);
                bonus = 0;
            }
        }
    }

    public static void bonusAdd()
    {
        if(chanceGet)
        {
            if(bonus == 0)
            {
                ScoreScript.bonusScore(Random.Range(5,16));
                Destroy(ups);
                chanceGet = false;
            }
            else
            {
                if (GamePlay.heartIndex < 3)
                {
                    GamePlay.heartIndex += 1;
                    LifeScript.hearts[GamePlay.heartIndex].SetActive(true);
                    Destroy(ups);
                    chanceGet = false;
                }
                else
                {
                    ScoreScript.bonusScore(Random.Range(5, 16));
                    Destroy(ups);
                    chanceGet = false;
                }
            }
        }
    }
}
