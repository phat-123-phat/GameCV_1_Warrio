using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleIcon : MonoBehaviour
{
    public Sprite onSprite;    
    public Sprite muteSprite;      
    public Button toggleButton;     
    private Image buttonImage;
    private bool isMuted = false;

    void Start()
    {
        buttonImage = toggleButton.GetComponent<Image>();
        toggleButton.onClick.AddListener(ToggleMusic);
    }

    void ToggleMusic()
    {
        isMuted = !isMuted;

        
        buttonImage.sprite = isMuted ? muteSprite : onSprite;
    }
}
