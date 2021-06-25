using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initialCountDown : MonoBehaviour
{
    // Start is called before the first frame update

    public static Text cd;
    public static GameObject iniCD;

    void Start()
    {
        iniCD = this.gameObject;
        cd = GetComponent<Text>();
    }
}
