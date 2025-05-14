using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SliderController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    private void Start()
    {
        // Đồng bộ giá trị slider với âm lượng hiện tại
        if (AudioManager.instance != null)
        {
            _musicSlider.value = AudioManager.instance.GetMusicVolume();
            _sfxSlider.value = AudioManager.instance.GetSFXVolume();
        }

        // Thêm listener để cập nhật âm lượng khi slider thay đổi
        _musicSlider.onValueChanged.AddListener(delegate { MusicVolume(); });
        _sfxSlider.onValueChanged.AddListener(delegate { SFXVolume(); });
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(_sfxSlider.value);
    }
}