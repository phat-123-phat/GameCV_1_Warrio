using UnityEngine;

public class MovementCharacterGizmos : MonoBehaviour
{
    public CharacterSettings characterSettings;
    public MovementCharacter movementCharacter;
    public Transform checkGroundPos  ;
    public float groundCheckRadius ;
    public LayerMask groundLayer;

    public Transform checkWallPos;
    public float wallCheckRadius ;
    public LayerMask wallLayer;
    private void Awake()
    {
        movementCharacter = GetComponent<MovementCharacter>();
        checkGroundPos = movementCharacter.checkGroundPos;
        checkWallPos = movementCharacter.checkWallPos;
        groundCheckRadius = characterSettings.groundCheckRadius;
        wallCheckRadius = characterSettings.wallCheckRadius;
        groundLayer = characterSettings.groundLayer;
        wallLayer = characterSettings.wallLayer;
    }
    private void Update()
    {
        groundCheckRadius = characterSettings.groundCheckRadius;
        wallCheckRadius = characterSettings.wallCheckRadius;
    }
    private void OnDrawGizmos()
    {
        if (checkGroundPos != null)
        {
            // Vẽ hình tròn kiểm tra ground
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(checkGroundPos.position, groundCheckRadius);
        }

        if (checkWallPos != null)
        {
            // Vẽ hình tròn kiểm tra wall
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(checkWallPos.position, wallCheckRadius);
        }
    }
}
