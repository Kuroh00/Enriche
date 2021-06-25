using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameObject PauseMenuUi;
    public static GameObject GameOverScreen;
    public static GameObject GamePlayScreen;
    public static GameObject SaveData;
    public static GameObject home;
    public static GameObject loading;
    
    public static GameState _instance;

    void Awake()
    {
        _instance = this;
    }

    public void OnPause()
    {
        sfxPlayer.src3.Pause();
        sfxPlayer.src1.Pause();
        PauseMenuUi = GameObject.Find("PauseMenu");
        sfxPlayer.proceed();
        PauseMenuUi.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResume()
    {
        sfxPlayer.src3.UnPause();
        sfxPlayer.src1.UnPause();
        sfxPlayer.proceed();
        PauseMenuUi.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ReturnToTitle()
    {
        ScoreScript.ResetScore();
        sfxPlayer.src3.Stop();
        _instance.StartCoroutine("TitleScreen");
    }

    public void onQuit()
    {
        if (GamePlayScreen == null)
        {
            GamePlayScreen = GameObject.Find("GamePlay");
        }
        GamePlayScreen.transform.GetChild(0).gameObject.SetActive(false);
        PauseMenuUi.transform.GetChild(0).gameObject.SetActive(false);
        _instance.StartCoroutine("QuitGame");
    }

    public static void GameOver()
    {
        SceneManager.LoadScene(5);
    }

    public void Save()
    {
        SaveData = GameObject.Find("SaveScore");
        GameOverScreen = GameObject.Find("GameFinish");
        SaveData.transform.GetChild(0).gameObject.SetActive(true);
        GameOverScreen.transform.GetChild(0).gameObject.SetActive(false);
    }

    public static void DontSave()
    {
        home = GameObject.Find("TitleOrExit");
        GameOverScreen = GameObject.Find("GameFinish");
        GameOverScreen.transform.GetChild(0).gameObject.SetActive(false);
        home.transform.GetChild(0).gameObject.SetActive(true);
        home.transform.GetChild(1).gameObject.SetActive(true);

    }

    public static void Saved()
    {
        if (home == null)
        { 
            home = GameObject.Find("TitleOrExit"); 
        }
        if (SaveData == null)
        {
            SaveData = GameObject.Find("SaveScore");
        }
       
        home.transform.GetChild(0).gameObject.SetActive(true);
        home.transform.GetChild(1).gameObject.SetActive(true);
        SaveData.transform.GetChild(0).gameObject.SetActive(false);
    }

    public static void nextStage()
    {
        if (GamePlayScreen == null)
        {
            GamePlayScreen = GameObject.Find("GamePlay");
        }
        GamePlayScreen.transform.GetChild(0).gameObject.SetActive(false);
        _instance.StartCoroutine("changeScene");
    }

    IEnumerator QuitGame()
    {
        SoundManager.PlaySound(SoundManager.Sound.clickQuit);
        Time.timeScale = 1.0f;

        yield return new WaitForSeconds(0.5f);

        Application.Quit();

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    IEnumerator TitleScreen()
    {
        Time.timeScale = 1.0f;
        
        SceneManager.LoadScene(0);

        yield return null;
    }

    IEnumerator changeScene()
    {
        if(loading == null)
        {
            loading = GameObject.Find("Loading");
        }

        loading.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(2);

        AsyncOperation aSyncLoad = SceneManager.LoadSceneAsync((SceneManager.GetActiveScene().buildIndex) + 1);

        while (!aSyncLoad.isDone)
        {
            yield return null;
        }
    }
}
