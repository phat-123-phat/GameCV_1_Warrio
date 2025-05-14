using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    public Transform checkGroundPos;

    public Transform checkWallPos;


    [SerializeField] private Settings settings; 
    private StateMachine movementStateMachine;

    private void Awake()
    {
        movementStateMachine = GetComponent<StateMachine>();
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra va chạm với các đối tượng có Tag trong danh sách damageTags
        if (settings.damageTags.Contains(collision.tag))
        {
           movementStateMachine.SetNextState(new HurtMovementState());
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm vật lý (nếu bẫy không phải trigger)
        if (settings.damageTags.Contains(collision.gameObject.tag))
        {
            movementStateMachine.SetNextState(new HurtMovementState());
        }
    }



}
