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
        thisBody.velocity = new Vector2(x * brzina, y * brzina);
        thisBody.velocity = Vector2.ClampMagnitude(thisBody.velocity, brzina);
        animator.SetFloat("dirX", x);
        animator.SetFloat("dirY", y);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        animator.SetFloat("dirX", thisBody.velocity.normalized.x);
        animator.SetFloat("dirY", thisBody.velocity.normalized.y);
        if (thisBody.velocity.x>0 && thisBody.velocity.y > 0){
            thisBody.velocity = new Vector2(1 * brzina, 1 * brzina);
        }
        if (thisBody.velocity.x>0 && thisBody.velocity.y < 0){
            thisBody.velocity = new Vector2(1 * brzina, -1 * brzina);
        }
        if (thisBody.velocity.x<0 && thisBody.velocity.y > 0){
            thisBody.velocity = new Vector2(-1 * brzina, 1 * brzina);
        }
        if (thisBody.velocity.x<0 && thisBody.velocity.y < 0){
            thisBody.velocity = new Vector2(-1 * brzina, -1 * brzina);
        }
        thisBody.velocity = Vector2.ClampMagnitude(thisBody.velocity, brzina);
    }
}
