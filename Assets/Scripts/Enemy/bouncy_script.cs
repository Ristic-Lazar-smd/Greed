using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncy_script : MonoBehaviour
{
    public Rigidbody2D thisBody;
    public Animator animator;

    int[] numbers = new int[] { -1, 1 };
    public int brzina = 300;

    void Start()
    {
        animator.GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(6, 6, true);

        int rangeX = UnityEngine.Random.Range(0, 2);
        int rangeY = UnityEngine.Random.Range(0, 2);
        int x = numbers[rangeX];
        int y = numbers[rangeY];
        thisBody.AddForce(new Vector2(x * brzina, y * brzina));
        animator.SetFloat("dirX", x);
        animator.SetFloat("dirY", y);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        animator.SetFloat("dirX", thisBody.velocity.normalized.x);
        animator.SetFloat("dirY", thisBody.velocity.normalized.y);
        //if (target.gameObject.CompareTag("Player"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
