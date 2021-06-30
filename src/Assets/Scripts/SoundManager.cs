using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{
 
    public enum Sound
    {
        clickStart,
        clickQuit,
        clickOptions,
        clickGM,
        bgmStart,
        bgmGame1,
        bgmGame2,
        bgmGame3,
        countDown,
        wrongSfx,
        rightSfx,
    }

    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
      
        audioSource.PlayOneShot(GetSoundFile(sound));
    }

    public static AudioClip GetSoundFile(Sound sound)
    {
        foreach (SoundLib.SoundFX soundFX in SoundLib.i.soundFXArray)
        {
            if (soundFX.sound == sound)
            {
                return soundFX.audioClip;
            }
        }
         
        return null;
        
    }

}
