using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{

    public static GameObject heart;
    public static GameObject heart1;
    public static GameObject heart2;
    public static GameObject heart3;
    public static GameObject[] hearts;

    void Awake()
    {
        hearts = GameObject.FindGameObjectsWithTag("Hearts");
        for(int x = 0; x > hearts.Length; x++)
        {
            hearts[x].GetComponent<Renderer>().enabled = true;
            Debug.Log(hearts[x]);
        }
    }

}
