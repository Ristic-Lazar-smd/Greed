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

    void Start(){
        playerTransform = PlayerMovement.playerInstance.GetComponent<Transform>();
        if(TryGetComponent<ColoredFlash>(out ColoredFlash _flash)){
            flash = _flash;
        }
    }

    void Update(){
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            int thisBulletDmg = collision.gameObject.GetComponent<Bullet>().bulletDmg;
            int dmgDone = (int)(thisBulletDmg * dmgMultiplier);
            if(flash)flash.FlashOnce(Color.white);
            enemyHP = enemyHP - dmgDone;

            /*calls the dmg numbers to pop-up*/
            GameObject thisHitNumbers = Instantiate(hitNumbers,transform.position,Quaternion.identity,transform);
            thisHitNumbers.GetComponent<TextMeshPro>().SetText(dmgDone.ToString());

            if(enemyHP <=0)
            {
                this.GetComponent<XpDrop>().Drop();
                this.GetComponent<EnemyHpOrbDrop>().Drop();
                UiScore.Instance.ChangeScore(this.GetComponent<XpDrop>().scoreWorth);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Sword")
        {
            if(canBeKnockedBack){Knockback();}
            if(flash){flash.FlashOnce(Color.white);}
            enemyHP = enemyHP - collision.gameObject.GetComponent<Sword>().swordDmg;

            if(enemyHP <=0)
            {
                this.GetComponent<XpDrop>().Drop();
                this.GetComponent<EnemyHpOrbDrop>().Drop();
                UiScore.Instance.ChangeScore(this.GetComponent<XpDrop>().scoreWorth);
                Destroy(gameObject);
            }
        }
    }
    public void Knockback(){
        enemyPosRelativeToPlayer= new Vector3(transform.position.x - playerTransform.position.x, transform.position.y - playerTransform.position.y).normalized; 
        transform.position = Vector2.MoveTowards(transform.position, (transform.position + enemyPosRelativeToPlayer), knockBackSpeed * Time.deltaTime);
    }
}
