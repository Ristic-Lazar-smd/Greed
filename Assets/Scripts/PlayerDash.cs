using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    Rigidbody2D body;
    Animator anim;

    private bool isDashing;
    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCooldown;
    private float dashTimeLeft;
    private float lastImageXposition;
    private float lastImageYposition;
    private float lastDash = -100f;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        body = GetComponent<Rigidbody2D>();
        
        //aleksa
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.CrossFade("test",0,0);
            if (Time.time >= (lastDash + dashCooldown))
            {
                AttemptToDash();
            }
        }
    }

    private void AttemptToDash()
    {
        isDashing = true;
        //this.gameObject.GetComponent<DamageableCharacter>().Invincible = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;

        PoolPlayerAfterImage.Instance.GetFromPool();
        lastImageXposition = transform.position.x;
        lastImageYposition = transform.position.y;
    }
    public void CheckDash()
    {
        if(isDashing){
            //anim.SetBool("AnimationLock",false);
            //anim.enabled=false;
            //anim.enabled=true;
            //anim.CrossFade("test",0,0);
            //anim.Play("test", -1, 0f);
            //anim.SetFloat("Dash",1);

            if (dashTimeLeft > 0){
                body.velocity = new Vector2(body.velocity.x * dashSpeed, body.velocity.y * dashSpeed);
                dashTimeLeft -= Time.deltaTime;
                if ((Mathf.Abs(transform.position.x - lastImageXposition) > distanceBetweenImages) || (Mathf.Abs(transform.position.y - lastImageYposition) > distanceBetweenImages))
                {
                    PoolPlayerAfterImage.Instance.GetFromPool();
                    lastImageXposition = transform.position.x;
                    lastImageYposition = transform.position.y;
                }
            }
            if (dashTimeLeft <= 0){
                //this.gameObject.GetComponent<DamageableCharacter>().Invincible = false;
                isDashing = false;
            }
        }
    }
}
