using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class SoundLib : MonoBehaviour
{
    private static SoundLib _i;

    public static SoundLib i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("SoundLib")) as GameObject).GetComponent<SoundLib>();
            return _i;
        }
    }

    public SoundFX[] soundFXArray;

    [System.Serializable]
    public class SoundFX
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
