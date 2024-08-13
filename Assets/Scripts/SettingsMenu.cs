using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterslider;
    public Slider musicslider;

    void Start()
    {
        float mastervolume = PlayerPrefs.GetFloat("MasterVolume", 0);
        float musicvolume = PlayerPrefs.GetFloat("MusicVolume", 0);
        audioMixer.SetFloat("mastervolume", mastervolume);
        audioMixer.SetFloat("musicvolume", musicvolume);
        masterslider.value = mastervolume;
        musicslider.value = musicvolume;
    }

    public void SetMasterVolume(float mastervolume)
    {
        PlayerPrefs.SetFloat("MasterVolume", mastervolume);
        PlayerPrefs.Save();
        audioMixer.SetFloat("mastervolume", mastervolume);
    }

    public void SetMusicVolume(float musicvolume)
    {
        PlayerPrefs.SetFloat("MusicVolume", musicvolume);
        PlayerPrefs.Save();
        audioMixer.SetFloat("musicvolume", musicvolume);
    }
}
