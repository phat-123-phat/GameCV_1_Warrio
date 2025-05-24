using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamCheckBoss : SwitchCam
{
    public float timeCheck;
    float _timeCoolDown;
    public CinemachineVirtualCamera originCam;
    bool isCheckCam;

    public GameObject GameObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(collisionTag))
        {
            CameraManager.SwitchCamera(cam);
            _timeCoolDown = timeCheck;
                isCheckCam = true;
        }
    }
    private void Update()
    {
        _timeCoolDown -= Time.deltaTime;

        if (_timeCoolDown <= 0  && isCheckCam)
        {
            CameraManager.SwitchCamera(originCam);
            isCheckCam=false;
            GameObject.SetActive(false);
        }
    }
}