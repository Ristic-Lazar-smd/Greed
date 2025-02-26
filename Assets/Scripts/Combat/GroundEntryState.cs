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
        duration = 0.57f; //duration mora da bude framerate podeljeno sa broj frejmova minus 0.01
        weaponAnimator.SetTrigger("Attack" + attackIndex);
        playerAnimator.SetTrigger("Attack" + attackIndex);
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
            }
        }
    }
}
