using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixerEffects;
    public AudioMixer audioMixerMusic;
    public void setvolumeEffects(float volume)
    {
        audioMixerEffects.SetFloat("volumeeffects", volume);
    }

    public void setvolumeMusic(float volume)
    {
        audioMixerMusic.SetFloat("volumemusic", volume);
    }
}
