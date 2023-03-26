using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpDrop : MonoBehaviour
{
    public Reference reference;
    public GameObject xp;
    public Sprite xpOrbSprite;

    public int xpGain;
    public int scoreWorth = 100;


    public void Drop()
    {
        xp.GetComponent<SpriteRenderer>().sprite = xpOrbSprite;
        XP newXp = (Instantiate(xp, this.transform.position , this.transform.rotation)).GetComponent<XP>();
        newXp.player = reference.player;
        newXp.xpGain = this.xpGain;
        //Destroy(this.gameObject);
    }
}
