using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// sve sto ima //aleksa iznad je novo za dash

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerInstance;
    DamageableCharacter damageableCharacter;
    Rigidbody2D body;
    Animator animator;
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

GameObject test;
    void Awake(){
        playerInstance = this;
        body = GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        animator = GetComponent<Animator>();
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
        animator.SetFloat("dirX", bodyVelocityXNormalized);
        animator.SetFloat("dirY", bodyVelocityYNormalized);

        //saljem animatoru ovo na klik kako bi znao kada da flipujem anim//
        if (Input.GetMouseButtonDown(0)){
            animator.SetFloat("MouseX", MouseRelToPlayer().x);
            animator.SetFloat("MouseY", MouseRelToPlayer().y);
        }
    }

    // temp solution for mouse poss, redudent, check ManualShoot script //
    public Vector3 MouseRelToPlayer(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        trueMousePos = new Vector3((worldPosition - gameObject.transform.position).x, (worldPosition - gameObject.transform.position).y).normalized;
        //Debug.Log(trueMousePos);    
        return trueMousePos;
    }

    private void FixedUpdate()
    {
        if(damageableCharacter.KnockedBack)return;
        if (animationLock){
            body.linearVelocity = Vector2.zero;
            sr.flipX = false;
        }
        else{
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
}
