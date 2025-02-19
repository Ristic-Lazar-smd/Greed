using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMobTest : MonoBehaviour
{
    public Reference reference;
    private Rigidbody2D rb;
    private Animator animator;
    private EnemyDmgTaken enemyDmgTaken;
    public float gluttonSpeed = 3f;
    public float chaseDistanceThreshold;
    public Animator swipe;

    float bodyVelocityXNormalized;
    float bodyVelocityYNormalized;
    float distance;

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
        if (enemyDmgTaken.canMove)
        {
            rb.linearVelocity = new Vector2(reference.player.transform.position.x - this.transform.position.x, reference.player.transform.position.y - this.transform.position.y).normalized * gluttonSpeed;
        }

        distance = Vector2.Distance(reference.player.transform.position, transform.position);
        //Debug.Log(distance);
        if (distance < chaseDistanceThreshold)
        {
            gluttonSpeed = 0f;
            swipe.SetTrigger("Attack1");
        }
        else
        {
            gluttonSpeed = 3f;
        }
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //enemyDmgTaken.canMove = false;
            //gluttonSpeed = 0f;
            Debug.Log("uso");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //enemyDmgTaken.canMove = true;
            //gluttonSpeed = 3f;
            Debug.Log("izaso");
        }
    }
}
