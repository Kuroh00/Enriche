using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ModeOneSelect : MonoBehaviour
{
    public void onSelectModeOne()
    {
        SceneManager.LoadScene(2);
    }
}
