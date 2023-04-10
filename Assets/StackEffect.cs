using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackEffect : MonoBehaviour
{
    [SerializeField] float stackDuration = 4f;
    [SerializeField] float offsetUp = 0.2f;

    public EnemyDmgTaken parentEnemyDmgTaken;

    float timer;

    void Awake(){
        transform.localPosition += new Vector3(1/10+0.2f,offsetUp,10);
        parentEnemyDmgTaken=GetComponentInParent<EnemyDmgTaken>();
    }

    void Update(){
        if (timer > 0) timer -= Time.deltaTime;
        else Destroy(gameObject);
    }
    public void SetStack(){
        timer = stackDuration;
    }
    void OnDestroy(){
        parentEnemyDmgTaken.dmgMultiplier=1;
        parentEnemyDmgTaken.nubmerOfStacks=0;
    }
}
