using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private float musicVolume = 1f; // Giá trị mặc định
    private float sfxVolume = 1f;   // Giá trị mặc định

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerMusic("Theme");
        // Khôi phục giá trị âm lượng khi khởi tạo
        musicSource.volume = musicVolume;
        sfxSource.volume = sfxVolume;
    }

    public void PlayerMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Âm thanh không tìm thấy");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlayerSFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Âm thanh không tìm thấy");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicVolume = volume; // Lưu giá trị
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxVolume = volume; // Lưu giá trị
        sfxSource.volume = volume;
    }

    // Phương thức để lấy giá trị âm lượng
    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }
}