using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Questions : ScriptableObject
{
    public string question;
    public int fontSize;
    public float lineSpacing;

    public string[] choices = new string[5];

}
