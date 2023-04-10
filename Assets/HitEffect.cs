using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitEffect : MonoBehaviour
{

    public GameObject stackEffect;
    public bool shouldStack=true;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnHit(GameObject target){
        //postavljam visual effect da pokazem da je procovano
        EnemyDmgTaken thisEnemyDmgTaken = target.GetComponent<EnemyDmgTaken>();

        //proveri da li postoji stack na enemy, ako da povecaj stack ako ne instanciraj stack
        switch (thisEnemyDmgTaken.nubmerOfStacks){
            case 0:{
                GameObject thisStackEffect = Instantiate(stackEffect,target.transform.position,Quaternion.identity,target.transform);
                thisEnemyDmgTaken.nubmerOfStacks++;
                thisEnemyDmgTaken.dmgMultiplier+=1f;
                thisStackEffect.GetComponent<TextMeshPro>().SetText("I");
                thisStackEffect.GetComponent<StackEffect>().SetStack();
            }return;
            case 1:{
                thisEnemyDmgTaken.nubmerOfStacks++;
                thisEnemyDmgTaken.dmgMultiplier+=1f;
                target.GetComponentInChildren<TextMeshPro>().SetText("II");
                target.GetComponentInChildren<StackEffect>().SetStack();
            }return;
            case 2:{
                thisEnemyDmgTaken.nubmerOfStacks++;
                thisEnemyDmgTaken.dmgMultiplier+=1f;
                target.GetComponentInChildren<TextMeshPro>().SetText("III");
                target.GetComponentInChildren<StackEffect>().SetStack();
            }return;
        }
    }
}
