using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncy_script : MonoBehaviour
{
    public Rigidbody2D thisBody;
    public Animator animator;

    public float brzina = 3;
    int[] numbers = new int[] { -1, 1 };

    void Awake(){
        animator.GetComponent<Animator>();
    }
    void Start()
    {
        int rangeX = UnityEngine.Random.Range(0, 2);
        int rangeY = UnityEngine.Random.Range(0, 2);
        int x = numbers[rangeX];
        int y = numbers[rangeY];
        thisBody.linearVelocity = new Vector2(x * brzina, y * brzina);
        thisBody.linearVelocity = Vector2.ClampMagnitude(thisBody.linearVelocity, brzina);
        animator.SetFloat("dirX", x);
        animator.SetFloat("dirY", y);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        animator.SetFloat("dirX", thisBody.linearVelocity.normalized.x);
        animator.SetFloat("dirY", thisBody.linearVelocity.normalized.y);
        if (thisBody.linearVelocity.x>0 && thisBody.linearVelocity.y > 0){
            thisBody.linearVelocity = new Vector2(1 * brzina, 1 * brzina);
        }
        if (thisBody.linearVelocity.x>0 && thisBody.linearVelocity.y < 0){
            thisBody.linearVelocity = new Vector2(1 * brzina, -1 * brzina);
        }
        if (thisBody.linearVelocity.x<0 && thisBody.linearVelocity.y > 0){
            thisBody.linearVelocity = new Vector2(-1 * brzina, 1 * brzina);
        }
        if (thisBody.linearVelocity.x<0 && thisBody.linearVelocity.y < 0){
            thisBody.linearVelocity = new Vector2(-1 * brzina, -1 * brzina);
        }
        thisBody.linearVelocity = Vector2.ClampMagnitude(thisBody.linearVelocity, brzina);
    }
}
