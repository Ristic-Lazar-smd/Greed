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
        duration = 0.33f; //duration mora da bude framerate podeljeno sa broj frejmova
        animator.SetTrigger("Attack" + attackIndex);
        PlayerMovement.playerInstance.animationLock = true;
        PlayerMovement.playerInstance.AttackStep();
    }

    public override void OnUpdate(){
        
        base.OnUpdate();

        if (fixedtime >= duration){
            if (shouldCombo){
                stateMachine.SetNextState(new GroundComboState());
                //PlayerMovement.playerInstance.animationLock = false;
            }
            else{
                stateMachine.SetNextStateToMain();
                PlayerMovement.playerInstance.animationLock = false;
            }
        }
    }
}
