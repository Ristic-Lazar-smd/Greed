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
    [SerializeField] Animator meleeAnimator;
    SpriteRenderer sr;
    PlayerDash playerDash;


    [HideInInspector] public Vector3 trueMousePos;
    public float runSpeed = 20.0f;
    
    [Tooltip("The distance that the player moves when doing a melee attack")]
    public float stepSpeed;
    float horizontal;
    float vertical;
    [HideInInspector] public float bodyVelocityXNormalized;
    [HideInInspector] public float bodyVelocityYNormalized;
    [HideInInspector] public bool attackStep;


    void Awake(){
        playerInstance = this;
        body = GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerDash = GetComponent<PlayerDash>();
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

        //Move player on melee attacks, attackStep is controlled by animations
        if (attackStep){
            transform.position = Vector2.MoveTowards(transform.position, transform.position + MouseRelToPlayer(), stepSpeed * Time.deltaTime);
        }
    }
    public void AttackStep(){
        transform.position = Vector2.MoveTowards(transform.position, transform.position + (MouseRelToPlayer()*9999), stepSpeed * Time.deltaTime);
    
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
        if (meleeAnimator.GetFloat("AnimationLock")!=0){
            body.linearVelocity = Vector2.zero;
            sr.flipX = false;
        }
        else{
            body.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed).normalized*runSpeed;

            //aleksa
            playerDash.CheckDash();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
           // Debug.Log(collision.collider.IsTouching);
            // Log the name of this object and the other object it collided with
            //Debug.Log($"Collision detected between {gameObject.name} and {collision.gameObject.name}");
            // Optional: Log the collider details
            //Collider2D otherCollider = collision.collider;
            //Debug.Log($"Other Collider: {otherCollider.name}");
        
        if (collision.gameObject.CompareTag("Enemy") && gameObject.tag!="Sword")
        {
            Vector2 test = new Vector2(transform.position.x - collision.transform.position.x, transform.position.y-collision.transform.position.y).normalized * 10;
            damageableCharacter.OnPlayerHit(collision.gameObject.GetComponent<Damage>().damage,test);
        }
    }
}
