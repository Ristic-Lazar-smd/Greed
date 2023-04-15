using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyDmgTaken : MonoBehaviour
{
    public GameObject hitNumbers;
    ColoredFlash flash;
    Transform playerTransform;
    Vector3 enemyPosRelativeToPlayer;
    GluttonMove gluttonMove;
    public GameObject explosion;
    /*[HideInInspector]*/ public bool canExplode = false;


    public int enemyHP;
    [Tooltip("Multiplies the dmg taken")]public float dmgMultiplier=1;
    [SerializeField]private bool canBeKnockedBack;
    [SerializeField]private float knockBackSpeed;
    [SerializeField]private float knockBackDistance;
    [HideInInspector]public bool knockedBack;

    public int nubmerOfStacks=0;
    public int dmgDone;

    void Awake(){
        playerTransform = PlayerMovement.playerInstance.GetComponent<Transform>();
        if(TryGetComponent<ColoredFlash>(out ColoredFlash _flash)){
            flash = _flash;
        }
    }
    void Update(){
        /*if(knockedBack && Vector3.Distance(transform.position,playerTransform.position)>knockBackDistance){
            gluttonMove.canMove=true;
            knockedBack=false;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            /*Enemy takes dmg*/
            int thisBulletDmg = collision.gameObject.GetComponent<Bullet>().bulletDmg;
            dmgDone = (int)(thisBulletDmg * dmgMultiplier);
            enemyHP = enemyHP - dmgDone;

            /*calls the dmg numbers to pop-up*/
            GameObject thisHitNumbers = Instantiate(hitNumbers,transform.position,Quaternion.identity,transform);
            thisHitNumbers.GetComponent<TextMeshPro>().SetText(dmgDone.ToString());

            /*Set stack if possible*/
            //ovo se radi na bulletu

            /*Enemy flashes*/
            if(flash)flash.FlashOnce(Color.white);       
        }
        if (collision.gameObject.tag == "Sword")
        {
            /*Enemy takes dmg*/
            int thisSwordDmg = collision.gameObject.GetComponent<Sword>().swordDmg;
            dmgDone = (int)(thisSwordDmg * dmgMultiplier);
            enemyHP = enemyHP - dmgDone;

            /*Set stack if possible*/
            HitEffect hitEffect= PlayerMovement.playerInstance.GetComponentInChildren<HitEffect>(false);
            if(hitEffect !=null && hitEffect.shouldStack)hitEffect.OnHit(this.gameObject);

            /*Flashes and gets knocked back*/
            if(canBeKnockedBack){Knockback();}
            if(flash){flash.FlashOnce(Color.white);}

            /*calls the dmg numbers to pop-up*/
            GameObject thisHitNumbers = Instantiate(hitNumbers,transform.position,Quaternion.identity,transform);
            thisHitNumbers.GetComponent<TextMeshPro>().SetText(dmgDone.ToString());
            //thisHitNumbers.GetComponent<HitNumbers>().parentTransform=this.transform;
        }
        if(collision.gameObject.tag == "Explosion")
        {
            /*Enemy takes dmg*/
            dmgDone = explosion.GetComponent<Explosion>().explosionDmg;
            enemyHP = enemyHP - dmgDone;

            /*Flashes and gets knocked back*/
            if (canBeKnockedBack) { Knockback(); }
            if (flash) { flash.FlashOnce(Color.white); }

            /*calls the dmg numbers to pop-up*/
            GameObject thisHitNumbers = Instantiate(hitNumbers, transform.position, Quaternion.identity, transform);
            thisHitNumbers.GetComponent<TextMeshPro>().SetText(dmgDone.ToString());
        }

        if(enemyHP <=0)
            {
                OnEnemyDeath();
            }
    }

    void OnEnemyDeath(){
        if (canExplode == true)
        {
            Explode();
        }
        this.GetComponent<XpDrop>().Drop();
        this.GetComponent<EnemyHpOrbDrop>().Drop();
        UiScore.Instance.ChangeScore(this.GetComponent<XpDrop>().scoreWorth);        
        Destroy(gameObject);
    }

    public void Knockback(){
        enemyPosRelativeToPlayer= new Vector3(transform.position.x - playerTransform.position.x, transform.position.y - playerTransform.position.y).normalized; 
        transform.position = Vector2.MoveTowards(transform.position, (transform.position + enemyPosRelativeToPlayer), knockBackSpeed * Time.deltaTime);

        /*GetComponent<GluttonMove>().canMove=false;
        knockedBack=true;
        Vector3 test = (transform.position + enemyPosRelativeToPlayer);
        GetComponent<Rigidbody2D>().AddForce(test*10f);
        GetComponent<Rigidbody2D>().velocity= new Vector2(this.transform.position.x - playerTransform.position.x, this.transform.position.y - playerTransform.position.y).normalized * knockBackSpeed;*/
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
