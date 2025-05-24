using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    [SerializeField] ParticleSystem movementParticle;

    [Range(0f, 10f)]
    [SerializeField] float occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] ParticleSystem fallParticle;

    [SerializeField] Rigidbody2D playerRb;

    float counter;

    private void Update()
    {
        counter += Time.deltaTime;

        if ( MovementBaseState.isGrounded && Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
        {
            if (counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;    
            }
        
        }
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            fallParticle.Play();
        }
    }
}
