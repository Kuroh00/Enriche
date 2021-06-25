using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer bgmMixer;
    public AudioMixer sfxMixer;

    public void SetBgmVol(float sliderValue)
    {
        bgmMixer.SetFloat("Bgm_Vol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSfxVol(float sliderValue)
    {
        sfxMixer.SetFloat("Sfx_Vol", Mathf.Log10(sliderValue) * 20);
    }
}
