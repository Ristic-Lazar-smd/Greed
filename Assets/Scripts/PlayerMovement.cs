using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    DamageableCharacter damageableCharacter;
    Rigidbody2D body;
    Animator animator;
    SpriteRenderer sr;

    float horizontal;
    float vertical;
    public float runSpeed = 20.0f;
    float bodyVelocityXNormalized;
    float bodyVelocityYNormalized;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        bodyVelocityXNormalized = body.velocity.normalized.x;
        bodyVelocityYNormalized = body.velocity.normalized.y;

        // Position clamp
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.593f, 5.05f);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -8.578f, 8.622f);
        transform.position = clampedPosition;
       
        //Animation
        animator.SetFloat("dirX", bodyVelocityXNormalized);
        animator.SetFloat("dirY", bodyVelocityYNormalized);
        //Flip sprite
        if (bodyVelocityXNormalized<0){
            sr.flipX = true;
        }
        else if (bodyVelocityXNormalized>0){
            sr.flipX = false;
        }
        
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed).normalized*runSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageableCharacter.OnPlayerHit(collision.gameObject.GetComponent<Damage>().damage);
        }
    }
}
