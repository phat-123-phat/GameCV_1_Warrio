using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamFightBoss : SwitchCam
{
    public GameObject uiHealthEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(collisionTag) && !Once)
        {
            CameraManager.SwitchCamera(cam);
            uiHealthEnemy.SetActive(true);
            Once = true;
        }
    }
}