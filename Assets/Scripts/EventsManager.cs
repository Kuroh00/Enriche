using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventsManager : MonoBehaviour
{
    public Toggle bgmToggle;
    public Toggle sfxToggle;
    public static GameObject gameModeSelect;
    public static GameObject supportButton;
    public static GameObject cutScenes;

    public static EventsManager instance;

    void Awake()
    {
        instance = this;
    }

    public static GameObject options;

    public void onStart()
    {
        sfxPlayer.proceed();
        instance.StartCoroutine(changeScene());
    }
    
    public void onQuit()
    {
        instance.StartCoroutine("QuitGame");
    }

    public void highScore()
    {
        SceneManager.LoadScene(6);
    }

    public void Options()
    {
        options = GameObject.Find("Options");
        options.transform.GetChild(0).gameObject.SetActive(true);
        if (sfxPlayer.src1.mute)
        {
            bgmToggle.isOn = true;
        }
        else if (!sfxPlayer.src1.mute)
        {
            bgmToggle.isOn = false;
        }

        if (sfxPlayer.src2.mute)
        {
            sfxToggle.isOn = true;
        }
        else if (!sfxPlayer.src2.mute)
        {
            sfxToggle.isOn = false;
        }
    }

    public void CloseOptions()
    {
        sfxPlayer.Return();
        options.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void muteBgm()
    {
        Debug.Log("BGM");
        if (bgmToggle.isOn)
        {
            sfxPlayer.src1.mute = true;
        }
        else if (!bgmToggle.isOn)
        {
            sfxPlayer.src1.mute = false;
        }
    }

    public void muteSfx()
    {
        Debug.Log("SFX");
        if (sfxToggle.isOn)
        {
            sfxPlayer.src2.mute = true;
            sfxPlayer.src3.mute = true;
        }
        else if (!sfxToggle.isOn)
        {
            sfxPlayer.src2.mute = false;
            sfxPlayer.src3.mute = false;
        }
    }

    public void ModeSelected()
    {
        if (gameModeSelect == null) 
        {
            gameModeSelect = GameObject.Find("GameModeSelect"); 
        }
        gameModeSelect.transform.GetChild(0).gameObject.SetActive(false);
        gameModeSelect.transform.GetChild(1).gameObject.SetActive(false);
        gameModeSelect.transform.GetChild(2).gameObject.SetActive(false);
        gameModeSelect.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void selectMale()
    {
        cutScenes = GameObject.Find("CutScene_John");
        CharaScript.johnOrjane = 0;
        cutScenes.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void selectFemale()
    {
        cutScenes = GameObject.Find("CutScene_Jane");
        CharaScript.johnOrjane = 1;
        cutScenes.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void BackToModeSelect()
    {
        if (gameModeSelect == null)
        {
            gameModeSelect = GameObject.Find("GameModeSelect");
        }
        sfxPlayer.Return();
        gameModeSelect.transform.GetChild(0).gameObject.SetActive(true);
        gameModeSelect.transform.GetChild(1).gameObject.SetActive(true);
        gameModeSelect.transform.GetChild(2).gameObject.SetActive(true);
        gameModeSelect.transform.GetChild(3).gameObject.SetActive(false);
    }
    public void BackToStart()
    {
        sfxPlayer.Return();
        instance.StartCoroutine(ChangeSceneBack());
    }
    public void RevealText()
    {
        if(supportButton == null)
        {
            supportButton = GameObject.Find("Support");
        }

        supportButton.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void HideText()
    {
        if (supportButton == null)
        {
            supportButton = GameObject.Find("Support");
        }
        supportButton.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OpenFbPage()
    {
        Application.OpenURL("https://www.facebook.com/SolLunarisStudio/");
    }

    IEnumerator changeScene()
    {
        if (cutScenes != null)
        {
            cutScenes.transform.GetChild(0).gameObject.SetActive(true);
        }

        AsyncOperation aSyncLoad = SceneManager.LoadSceneAsync((SceneManager.GetActiveScene().buildIndex) + 1);

        while (!aSyncLoad.isDone)
        {
            yield return null;   
        }
    }
    IEnumerator ChangeSceneBack()
    {

        AsyncOperation aSyncLoad = SceneManager.LoadSceneAsync((SceneManager.GetActiveScene().buildIndex) - 1);

        while (!aSyncLoad.isDone)
        {
            yield return null;
        }
    }


    IEnumerator QuitGame()
    {
        SoundManager.PlaySound(SoundManager.Sound.clickQuit);

        yield return new WaitForSeconds(1);

        Application.Quit();
    }
}
