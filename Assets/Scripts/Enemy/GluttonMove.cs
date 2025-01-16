using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonMove : MonoBehaviour
{
    public Reference reference;
    private Rigidbody2D rb;
    private Animator animator;
    private EnemyDmgTaken enemyDmgTaken;
    public float gluttonSpeed = 3f;

    float bodyVelocityXNormalized;
    float bodyVelocityYNormalized;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyDmgTaken = GetComponent<EnemyDmgTaken>();
    }
    
    private void Update(){
        bodyVelocityXNormalized = rb.linearVelocity.normalized.x;
        bodyVelocityYNormalized = rb.linearVelocity.normalized.y;

        animator.SetFloat("dirX", bodyVelocityXNormalized);
        animator.SetFloat("dirY", bodyVelocityYNormalized);
    }

    private void FixedUpdate()
    {
        if(enemyDmgTaken.canMove){
            rb.linearVelocity= new Vector2(reference.player.transform.position.x-this.transform.position.x, reference.player.transform.position.y-this.transform.position.y).normalized * gluttonSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
