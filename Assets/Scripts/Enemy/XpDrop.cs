using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpDrop : MonoBehaviour
{
    public Reference reference;
    public GameObject xp;
    public Sprite xpOrbSprite;
    //private ListOfXpOrbs xpOrbs;

    public int xpGain;
    public int scoreWorth = 100;


    public void Drop()
    {
        xp.GetComponent<SpriteRenderer>().sprite = xpOrbSprite;
        XP newXp = (Instantiate(xp, this.transform.position , this.transform.rotation)).GetComponent<XP>();
        newXp.player = reference.player;
        newXp.xpGain = this.xpGain;
        this.GetComponent<Reference>().player.GetComponent<PlayerExp>().gameManager.GetComponent<ListOfXpOrbs>().xpOrbs.Add(newXp.gameObject);
        //xpOrbs.xpOrbs.Add(newXp.gameObject);
        //Destroy(this.gameObject);
    }
}
