using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource sound;
    private AudioSource music;
    private void Awake()
    {
        instance = this;
        sound = GetComponent<AudioSource>();
        music = transform.GetChild(0).GetComponent<AudioSource>();
        ChangeMusic(0);
        ChangeVolum(0);
    }
    public void PlaySound(AudioClip _sound)
    {
        sound.PlayOneShot(_sound);
    }
    public void ChangeVolum(float _change)
    {
        float baseVolume = 1f;
        float currentVolum = PlayerPrefs.GetFloat("Sound");
        currentVolum += _change;
        if (currentVolum > 1)
        {
            currentVolum = 0;
        }else if(currentVolum < 0)
        {
            currentVolum = 1;
        }
        float finalVolum = currentVolum * baseVolume;
        sound.volume = finalVolum;

        PlayerPrefs.SetFloat("Sound", currentVolum);     
    }
    public void ChangeMusic(float _change)
    {
        float baseVolume = 0.3f;
        float currentVolum = PlayerPrefs.GetFloat("Music", 0);
        currentVolum += _change;
        if (currentVolum > 1)
        {
            currentVolum = 0;
        }
        else if (currentVolum < 0)
        {
            currentVolum = 1;
        }

        music.volume = currentVolum * baseVolume;   

        PlayerPrefs.SetFloat("Music", currentVolum);
    }
}
