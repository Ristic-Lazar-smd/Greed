using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    Rigidbody2D body;
    Animator playerAnimator;
    StateMachine meleeStateMachine;
    DamageableCharacter damageableCharacter;

    public bool isDashing;
    public float dashDuration;
    public float dashSpeed;
    public float dashCooldown;
    public float distanceBetweenImages;
    private float dashTimeLeft;
    private float lastImageXposition;
    private float lastImageYposition;
    private float lastDash = -100f;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        meleeStateMachine = GetComponent<StateMachine>();
        damageableCharacter = GetComponent<DamageableCharacter>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= (lastDash + dashCooldown))
            {
                playerAnimator.CrossFade("test",0,0);
                AttemptToDash();
            }
        }


        //ovo omogucava animation cancel iz dasha u bilo koj napad//
        if(isDashing && Input.GetMouseButtonDown(0)){
            switch(meleeStateMachine.CurrentState.ToString()){
                case"IdleCombatState":{meleeStateMachine.SetNextState(new GroundEntryState());}
                return;
                case"GroundEntryState":{meleeStateMachine.SetNextState(new GroundComboState());}
                return;
                case"GroundComboState":{meleeStateMachine.SetNextState(new GroundFinisherState());}
                return;
            }
        }
    }

    private void AttemptToDash()
    {
        isDashing = true;
        damageableCharacter.Invincible = true;
        dashTimeLeft = dashDuration;
        lastDash = Time.time;

        PoolPlayerAfterImage.Instance.GetFromPool();
        lastImageXposition = transform.position.x;
        lastImageYposition = transform.position.y;
    }
    public void CheckDash()
    {
        if(isDashing){
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
                isDashing = false;
            }
        }
    }
}
