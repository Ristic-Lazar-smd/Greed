using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonMove : MonoBehaviour
{
    public Reference reference;
    private Rigidbody2D rb;
    private Animator animator;
    public float gluttonSpeed = 3f;

    float bodyVelocityXNormalized;
    float bodyVelocityYNormalized;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    private void Update(){
        bodyVelocityXNormalized = rb.velocity.normalized.x;
        bodyVelocityYNormalized = rb.velocity.normalized.y;

        animator.SetFloat("dirX", bodyVelocityXNormalized);
        animator.SetFloat("dirY", bodyVelocityYNormalized);
    }

    private void FixedUpdate()
    {
        rb.velocity= new Vector2(reference.player.transform.position.x-this.transform.position.x, reference.player.transform.position.y-this.transform.position.y).normalized * gluttonSpeed;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
