using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDash : MonoBehaviour
{
    Rigidbody2D body;
    Animator playerAnimator;
    [SerializeField] Animator meleeAnimator;
    StateMachine meleeStateMachine;
    DamageableCharacter damageableCharacter;
    Collider2D playerColider;
    public Image dashImage;

    public bool isDashing;
    public float dashDuration;
    public float dashSpeed;
    public float dashCooldown;
    public float distanceBetweenImages;
    private float dashTimeLeft;
    private float lastImageXposition;
    private float lastImageYposition;
    private float lastDash = -100f;

    string cacheCurentMeleeState;


    //pre sam koristio isDashing da kontrolis koja skripta moze da cita levi klik i to je izazivalo probleme zato sto moram da stavim isDashing na false da bih zaustavio animaciju, to ujedno pusti sve skripte da citaju input i zbog toga je bilo problema. Zato umesto isDashing sam uveo novi bool boolDashComboFix koji se setuje isto kad i isDashing ali njega ne gasim kad i isDashing.
    public bool boolDashComboFix;
    float dashTimer;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        meleeStateMachine = GetComponent<StateMachine>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        playerColider = GetComponent<Collider2D>();
    }

    void Update()
    {
        dashTimer -= Time.deltaTime;
        if (dashTimer <= 0){
            boolDashComboFix = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= (lastDash + dashCooldown))
            {
                dashTimer = dashDuration;
                //playerAnimator.CrossFade("test",0,0);
                AttemptToDash();
            }
        }


        if (isDashing)
        {
            var tempColor = dashImage.color;
            tempColor.a = 0f;
            dashImage.color = tempColor;
            playerColider.enabled = false;
            cacheCurentMeleeState = meleeStateMachine.CurrentState.ToString();
            meleeStateMachine.SetNextStateToMain();
        }
        else if(Time.time >= (lastDash + dashCooldown))
        {
            var tempColor = dashImage.color;
            tempColor.a = 1f;
            dashImage.color = tempColor;
            playerColider.enabled = true;
        }




        //ovo omogucava animation cancel iz dasha u bilo koj napad//
        if(isDashing && Input.GetMouseButtonDown(0) && WeaponState.instance.weaponStateIsMelee){
            switch(cacheCurentMeleeState){
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
        meleeAnimator.SetFloat("AnimationLock",0);
        playerAnimator.SetTrigger("Dash");
        boolDashComboFix = true;
        isDashing = true;
        damageableCharacter.Invincible = true;
        damageableCharacter.KnockedBack=false; //you can dash out of hitstun
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
                body.linearVelocity = new Vector2(body.linearVelocity.x * dashSpeed, body.linearVelocity.y * dashSpeed);
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
                boolDashComboFix = false;
            }
        }
    }
}
