using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// sve sto ima //aleksa iznad je novo za dash

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerInstance;
    DamageableCharacter damageableCharacter;
    Rigidbody2D body;
    Animator playerAnimator;
    //[SerializeField] Animator meleeAnimator;
    SpriteRenderer sr;
    PlayerDash playerDash;
    AttackStep attackStep;


    [HideInInspector] public Vector3 trueMousePos;
    public float runSpeed;
    
    [Tooltip("The distance that the player moves when doing a melee attack")]

    float horizontal;
    float vertical;
    [HideInInspector] public float bodyVelocityXNormalized;
    [HideInInspector] public float bodyVelocityYNormalized;
    [HideInInspector] public bool animationLock = false;
    float lastDirection;
    AnimatorStateInfo playerAnimatorStateInfo;

    float delay;
    void Awake(){
        playerInstance = this;
        body = GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        playerAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerDash = GetComponent<PlayerDash>();
        attackStep = GetComponent<AttackStep>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        bodyVelocityXNormalized = body.linearVelocity.normalized.x;
        bodyVelocityYNormalized = body.linearVelocity.normalized.y;

        // Position clamp
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.593f, 5.05f);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -8.578f, 8.622f);
        transform.position = clampedPosition;
       
        //Animation
        playerAnimator.SetFloat("dirX", bodyVelocityXNormalized);
        playerAnimator.SetFloat("dirY", bodyVelocityYNormalized);

        //saljem animatoru ovo na klik kako bi znao kada da flipujem anim//
        if (Input.GetMouseButtonDown(0)){
            playerAnimator.SetFloat("MouseX", MouseRelToPlayer().x);
            playerAnimator.SetFloat("MouseY", MouseRelToPlayer().y);
        }

        //Animation flip
        if (delay>0)delay -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0)){
            delay=0.1f;
            lastDirection=1;
            if (MouseRelToPlayer().x<0) lastDirection=-1;
        }
        if(bodyVelocityXNormalized!=0 && delay<=0) lastDirection=bodyVelocityXNormalized;
        if (lastDirection<0)sr.flipX=true;
        else sr.flipX=false;

        //Animation lock
        if(playerAnimator.GetFloat("AnimationLock")!=0) animationLock=true;
        else animationLock=false;
    }


    private void FixedUpdate()
    {
        if(damageableCharacter.KnockedBack)return;
        if (animationLock){
            body.linearVelocity = Vector2.zero;
            sr.flipX = false;
        } else{
            body.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed).normalized*runSpeed;
        }
        playerDash.CheckDash();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gameObject.tag!="Sword")
        {
            Vector2 test = new Vector2(transform.position.x - collision.transform.position.x, transform.position.y-collision.transform.position.y).normalized * 10;
            damageableCharacter.OnPlayerHit(collision.gameObject.GetComponent<Damage>().damage,test);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 test = new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y).normalized * 10;
            damageableCharacter.OnPlayerHit(collision.gameObject.GetComponent<Damage>().damage, test);
        }
    }




            // temp solution for mouse poss, redudent, check ManualShoot script //
            public Vector3 MouseRelToPlayer(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        trueMousePos = new Vector3((worldPosition - gameObject.transform.position).x, (worldPosition - gameObject.transform.position).y).normalized;  
        return trueMousePos;
    }
}
