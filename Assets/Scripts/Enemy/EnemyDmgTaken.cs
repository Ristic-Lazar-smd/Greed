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


    public int enemyHP;
    [Tooltip("Multiplies the dmg taken")]public float dmgMultiplier=1;
    [SerializeField]private bool canBeKnockedBack;
    [SerializeField]private float knockBackSpeed;

    public int nubmerOfStacks=0;

    void Start(){
        playerTransform = PlayerMovement.playerInstance.GetComponent<Transform>();
        if(TryGetComponent<ColoredFlash>(out ColoredFlash _flash)){
            flash = _flash;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            /*Enemy takes dmg*/
            int thisBulletDmg = collision.gameObject.GetComponent<Bullet>().bulletDmg;
            int dmgDone = (int)(thisBulletDmg * dmgMultiplier);
            enemyHP = enemyHP - dmgDone;

            /*Set stack if possible*/
            HitEffect hitEffect= PlayerMovement.playerInstance.GetComponentInChildren<HitEffect>(false);
            if(hitEffect !=null && hitEffect.shouldStack)hitEffect.OnHit(this.gameObject);

            /*Enemy flashes*/
            if(flash)flash.FlashOnce(Color.white);

            /*calls the dmg numbers to pop-up*/
            GameObject thisHitNumbers = Instantiate(hitNumbers,transform.position,Quaternion.identity,transform);
            thisHitNumbers.GetComponent<TextMeshPro>().SetText(dmgDone.ToString());

            if(enemyHP <=0)
            {
                OnEnemyDeath();
            }
        }
        if (collision.gameObject.tag == "Sword")
        {
            /*Enemy takes dmg*/
            int thisSwordDmg = collision.gameObject.GetComponent<Sword>().swordDmg;
            int dmgDone = (int)(thisSwordDmg * dmgMultiplier);
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

            if(enemyHP <=0)
            {
                OnEnemyDeath();
            }
        }
    }

    void OnEnemyDeath(){
        this.GetComponent<XpDrop>().Drop();
        this.GetComponent<EnemyHpOrbDrop>().Drop();
        UiScore.Instance.ChangeScore(this.GetComponent<XpDrop>().scoreWorth);
        Destroy(gameObject);
    }

    public void Knockback(){
        enemyPosRelativeToPlayer= new Vector3(transform.position.x - playerTransform.position.x, transform.position.y - playerTransform.position.y).normalized; 
        transform.position = Vector2.MoveTowards(transform.position, (transform.position + enemyPosRelativeToPlayer), knockBackSpeed * Time.deltaTime);
    }
}
