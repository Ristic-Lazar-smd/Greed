using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine){
        
        base.OnEnter(_stateMachine);

        //Attack
        attackIndex = 1;
        duration = 0.64f; //duration mora da bude framerate podeljeno sa broj frejmova
        weaponAnimator.SetTrigger("Attack" + attackIndex);
        playerAnimator.SetTrigger("Attack" + attackIndex);
        PlayerMovement.playerInstance.animationLock = true;
        meleeMain.UpdateAttackDirection();
        //attackStep.Step();
    }

    public override void OnUpdate(){
        
        base.OnUpdate();
        
        if (fixedtime >= duration){
            if (shouldCombo){
                stateMachine.SetNextState(new GroundComboState());
            }
            else{
                stateMachine.SetNextStateToMain();
                PlayerMovement.playerInstance.animationLock = false;
            }
        }
    }
}
