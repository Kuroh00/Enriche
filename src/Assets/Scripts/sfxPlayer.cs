using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sfxPlayer : MonoBehaviour
{
    [NonSerialized] public bool bgmStart = false;
    [NonSerialized] public bool bgmGame = false;
    public static AudioSource src1;
    public static AudioSource src2;
    public static AudioSource src3;
    public static sfxPlayer _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
            AudioSource[] audioSrcs = GetComponents<AudioSource>();
            src1 = audioSrcs[0];
            src2 = audioSrcs[1];
            src3 = audioSrcs[2];
        }
        else if (_instance != null)
        {
            Destroy(this);
        }
    }


    void Update()
    {
        if ((SceneManager.GetActiveScene().buildIndex < 2 || SceneManager.GetActiveScene().buildIndex == 5) && !bgmStart)
        {
            src2.Stop();
            src1.clip = SoundManager.GetSoundFile(SoundManager.Sound.bgmStart);
            src1.loop = true;
            src1.Play();
            bgmStart = true;
            bgmGame = false;
        }

        else if (SceneManager.GetActiveScene().buildIndex == 2 && bgmStart)
        {
            src1.clip = SoundManager.GetSoundFile(SoundManager.Sound.bgmGame1);
            src1.loop = true;
            src1.Play();
            bgmGame = true;
            bgmStart = false;
        }

        else if (SceneManager.GetActiveScene().buildIndex == 3 && bgmGame)
        {
            src1.clip = SoundManager.GetSoundFile(SoundManager.Sound.bgmGame2);
            src1.loop = true;
            src1.Play();
            bgmGame = false;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4 && !bgmGame)
        {
            src1.clip = SoundManager.GetSoundFile(SoundManager.Sound.bgmGame3);
            src1.loop = true;
            src1.Play();
            bgmGame = true;
        }
    }

    public static void rightAnswer()
    {
        src2.clip = SoundManager.GetSoundFile(SoundManager.Sound.rightSfx);
        src2.Play();
    }

    public static void wrongAnswer()
    {
        src2.clip = SoundManager.GetSoundFile(SoundManager.Sound.wrongSfx);
        src2.Play();
    }

    public static void countDown()
    {
        src3.clip = SoundManager.GetSoundFile(SoundManager.Sound.countDown);
        src3.Play();
    }

    public static void countDownStop()
    {
        src3.Stop();
    }

    public static void proceed()
    {
        src2.clip = SoundManager.GetSoundFile(SoundManager.Sound.clickStart);
        src2.Play();
    }
    public static void Return()
    {
        src2.clip = SoundManager.GetSoundFile(SoundManager.Sound.clickQuit);
        src2.Play();
    }


}
