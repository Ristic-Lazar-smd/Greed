using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitEffect : MonoBehaviour
{

    public GameObject stackEffect;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnHit(GameObject target){
        //postavljam visual effect da pokazem da je procovano

        //proveri da li postoji stack na enemy, ako da povecaj stack ako ne instanciraj stack
        GameObject thisStackEffect = Instantiate(stackEffect,target.transform.position,Quaternion.identity,target.transform);
        thisStackEffect.GetComponent<TextMeshPro>().SetText("I");
        thisStackEffect.GetComponent<StackEffect>().SetStack();


        //povecavam dmgMultiplier, ali tek na 2. stack, posto ako povecam odmah ima da se primeni bonus dmg na prvi hit koji primenjuje 1. stack
        target.GetComponent<EnemyDmgTaken>().dmgMultiplier+=0.2f;
    }
}
