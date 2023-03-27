using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgTaken : MonoBehaviour
{
    ColoredFlash flash;
    Transform playerTransform;
    Vector3 enemyPosRelativeToPlayer;

    public int enemyHP;
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
            if(flash)flash.FlashOnce(Color.white);
            enemyHP = enemyHP - collision.gameObject.GetComponent<Bullet>().bulletDmg;
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
