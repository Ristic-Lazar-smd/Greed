using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostShadowWalk : MonoBehaviour
{
    private Collider2D[] collidersToIgnore;
    public Reference reference;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 chargeDirection;

    public float shadowSpeed = 3f;
    public float attackRange = 5f;
    public float attackSpeed = 5f;
    public float delayAfterAttack = 0.5f;
    private bool attack = false;
    private bool check = false;
    private bool reverse = false;
    private bool canwalk = true;

  
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start(){
        /*Lost Shadow ignores walls that are in "allColliders"*/
        collidersToIgnore = ArenaWalls.arenaWallsInstance.allColliders;
        for(int i = 0; i< collidersToIgnore.Length;i++){
        Physics2D.IgnoreCollision(collidersToIgnore[i], GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, reference.player.transform.position) < attackRange && canwalk==true ){
            attack = true;
            
            if (attack != check){
                check = attack;
                animator.Play("Lost_Shadow_Charge");
                canwalk = false;
                GetChargeDirection();
            }
        reverse = true;

        }else if (Vector3.Distance(transform.position, reference.player.transform.position) > attackRange ){
            attack = false;
            check = false;
            
            if (attack != reverse){
                reverse = attack;
                animator.Play("Lost_Shadow_Un_Charge");         
                StartCoroutine(WaitForFunction());
                rb.velocity = new Vector2 (0,0);  
            }
        }
    }

    private void FixedUpdate()
    {
        if (!attack && canwalk==true){
            rb.velocity = new Vector2(reference.player.transform.position.x-this.transform.position.x, reference.player.transform.position.y-this.transform.position.y).normalized * shadowSpeed;
        }else if (attack && canwalk==false){
            rb.velocity = chargeDirection * attackSpeed;
        }
    }

    private void GetChargeDirection(){
        chargeDirection = new Vector2 (reference.player.transform.position.x-this.transform.position.x, reference.player.transform.position.y-this.transform.position.y).normalized;
    }

    IEnumerator WaitForFunction(){
        yield return new WaitForSeconds(delayAfterAttack);
        canwalk=true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
    }
}