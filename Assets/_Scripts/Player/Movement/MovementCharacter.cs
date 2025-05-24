using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementCharacter : MonoBehaviour
{
    public Transform checkGroundPos;

    public Transform checkWallPos;

    public GameObject MenuDead;

    public bool isReturnByDead = false;
    [SerializeField] private CharacterSettings settings; 
    private StateMachine movementStateMachine;

    private void Awake()
    {
        movementStateMachine = GetComponent<StateMachine>();
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (settings.damageTags.Contains(collision.tag))
        {
           movementStateMachine.SetNextState(new HurtMovementState());
            if (isReturnByDead)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Kiểm tra va chạm với các đối tượng có Tag trong danh sách damageTags
        if (settings.damageTags.Contains(collision.tag) && collision.gameObject.CompareTag("Trap"))
        {
            movementStateMachine.SetNextState(new HurtMovementState());

        }
    }



}
