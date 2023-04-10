using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpOrbDrop : MonoBehaviour
{
    //public int percentageOfMaxHpGained;
    public Reference reference;
    public int chanceToDrop;
    public GameObject hpOrb;
    public Sprite hpOrbSprite;

    private int random;
    private Vector3 space;


    public void Drop()
    {
        space = new Vector3(0.5f, 0.0f);
        random = Random.Range(1, 100);
        if(random<=chanceToDrop)
        {
            hpOrb.GetComponent<SpriteRenderer>().sprite = hpOrbSprite;
            HpOrb newHpOrb = (Instantiate(hpOrb, this.transform.position + space, this.transform.rotation)).GetComponent<HpOrb>();
            newHpOrb.player = reference.player;
            //newHpOrb.percentageOfMaxHpGained = this.percentageOfMaxHpGained;
            //Destroy(this.gameObject);
        }
    }
}
