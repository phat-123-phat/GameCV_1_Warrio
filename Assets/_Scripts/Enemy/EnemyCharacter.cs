using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
using Cinemachine;

public class EnemyCharacter : MonoBehaviour
{
    public Rigidbody2D laser ;

    public Animator laserAnimator ;

    public ShakeData laserShakeData ;

    public Animator EnemyAnimation ;

    public CinemachineVirtualCamera camFace2;
    
    public GameObject HealthBar ;

    public GameObject Arm ;
    public GameObject laserActive;

    public Rigidbody2D laser1;
    public Animator laserAnimator1;
    public Rigidbody2D laser2;
    public Animator laserAnimator2;
    public Rigidbody2D laser3;
    public Animator laserAnimator3;
    public Rigidbody2D laser4;
    public Animator laserAnimator4;

    public Transform Tagert1;
    public Transform Tagert2;
    public Transform Tagert3;
    public Transform Tagert4;


    public GameObject MenuEnd;

    public Animator WarningLaserAnimator;
    public Animator WarningLaserAnimator1;
    public Animator WarningLaserAnimator2;
    public Animator WarningLaserAnimator3;
    public Animator WarningLaserAnimator4;

    public string MusicBossFace2;
}
