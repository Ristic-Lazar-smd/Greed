using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBaseState : State
{
    
    public float duration;
    protected Animator weaponAnimator;
    protected Animator playerAnimator;

    protected bool shouldCombo; 
    protected int attackIndex;
    protected Collider2D hitCollider;
    private List<Collider2D> collidersDamaged;
    private GameObject HitEffectPrefab;

    PlayerDash playerDash;
    protected MeleeMain meleeMain;
    protected AttackStep attackStep;

    // Input buffer Timer
    private float AttackPressedTimer = 0;

    //delay combo stuff
    protected bool flag;
    //adjust this to widen of shorten the window in which a player can execute the delay attack combo
    protected float windowOfAttack = 0.12f;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        meleeMain = GameObject.Find("MeleeFloat").GetComponent<MeleeMain>();
        weaponAnimator = meleeMain.GetComponentInChildren<Animator>();
        playerAnimator = PlayerMovement.playerInstance.GetComponent<Animator>();
        
        attackStep = meleeMain.GetComponent<AttackStep>();
        collidersDamaged = new List<Collider2D>();
        hitCollider = GetComponent<ComboCharacter>().hitbox;
        //HitEffectPrefab = GetComponent<ComboCharacter>().Hiteffect;

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        AttackPressedTimer -= Time.deltaTime;

        if (weaponAnimator.GetFloat("Weapon.Active") > 0f){
            Attack();
        }


        /*if (Input.GetMouseButtonDown(0))
        {
            AttackPressedTimer = 0.01f;
        }*/

        if (Input.GetMouseButtonDown(0) /*&& animator.GetFloat("AttackWindow.Open") > 0f*/ && !(GetComponent<PlayerDash>().boolDashComboFix)/*&& AttackPressedTimer > 0*/){
            shouldCombo = true;
        }
    }

    public override void OnExit(){
        base.OnExit();
    }

    protected void Attack(){
        Collider2D[] collidersToDamage = new Collider2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = true;
        int colliderCount = Physics2D.OverlapCollider(hitCollider, filter, collidersToDamage);
        for (int i = 0; i < colliderCount; i++){
            if (!collidersDamaged.Contains(collidersToDamage[i])){
                TeamComponent hitTeamComponent = collidersToDamage[i].GetComponentInChildren<TeamComponent>();

                // Only check colliders with a valid Team Componnent attached
                if (hitTeamComponent && hitTeamComponent.teamIndex == TeamIndex.Enemy){
                    GameObject.Instantiate(HitEffectPrefab, collidersToDamage[i].transform);
                    Debug.Log("Enemy Has Taken:" + attackIndex + "Damage");
                    collidersDamaged.Add(collidersToDamage[i]);
                }
            }
        }
    }

}
