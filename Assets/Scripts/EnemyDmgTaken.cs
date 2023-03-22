using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgTaken : MonoBehaviour
{
    ColoredFlash flash;
    public int enemyHP;

    void Start(){
        if(TryGetComponent<ColoredFlash>(out ColoredFlash _flash)){
            flash = _flash;
        }
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
                UiScore.Instance.ChangeScore(this.GetComponent<XpDrop>().scoreWorth);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Sword")
        {
            if(flash)flash.FlashOnce(Color.white);
            enemyHP = enemyHP - collision.gameObject.GetComponent<Sword>().swordDmg;
            if(enemyHP <=0)
            {
                this.GetComponent<XpDrop>().Drop();
                UiScore.Instance.ChangeScore(this.GetComponent<XpDrop>().scoreWorth);
                Destroy(gameObject);
            }
            

        }
    }
}
