using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudio : MonoBehaviour
{
    public string nameAudio;
    public bool once = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && once)
        {
            once = false;
            AudioManager.instance.PlayerMusic(nameAudio);
        }
    }
}
