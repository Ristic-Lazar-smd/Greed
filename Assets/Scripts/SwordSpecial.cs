using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpecial : MonoBehaviour
{
    Animator animator;
    CircleCollider2D spinHitbox;

    public float spinDuration;
    float spinTimer; 

    bool _isSpinning;
    [HideInInspector]public bool isSpinning{
        get{return _isSpinning;}
        set{
            _isSpinning=value;
            if(_isSpinning){
                animator.SetBool("IsSpinning",true);
                spinHitbox.enabled=true;
            }
            else {
                animator.SetBool("IsSpinning",false);
                spinHitbox.enabled=false;
            }
        }
    }

    void Awake(){
        animator = GetComponentInParent<Animator>();
        spinHitbox = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (spinTimer > 0){spinTimer -= Time.deltaTime;}
        else{
            isSpinning = false;
        }
        if (Input.GetMouseButtonDown(1) && WeaponState.instance.weaponStateIsMelee){
            isSpinning = true;
            spinTimer = spinDuration;
            animator.CrossFade("Player_attack_spin",0,0);
        }
    }
}
