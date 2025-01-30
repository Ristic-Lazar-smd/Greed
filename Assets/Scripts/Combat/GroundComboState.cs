using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class GroundComboState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        

        //Attack
        attackIndex = 2;
        duration = 0.42f;
        //duration = 2.00f;
        animator.SetTrigger("Attack" + attackIndex);
        PlayerMovement.playerInstance.animationLock = true;
        meleeMain.UpdateAttackDirection();
        attackStep.Step();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (fixedtime >= duration)
        {
            if (shouldCombo)
            {
                stateMachine.SetNextState(new GroundFinisherState());
                shouldCombo = false;
            }
            else
            {
                stateMachine.SetNextStateToMain();
                PlayerMovement.playerInstance.animationLock = false;
            }
        }

        //attack delay combo
        if(fixedtime<duration-windowOfAttack && Input.GetMouseButtonDown(0)){
            flag = true;
        }    
        if (!flag && fixedtime >= duration-windowOfAttack && fixedtime <= duration ){

            if (Input.GetMouseButtonDown(0)){
                stateMachine.SetNextState(new GroundDelayState());
                //ebug.Log("delayCombo");
                //stateMachine.SetNextStateToMain();
                //PlayerMovement.playerInstance.animationLock = false;
            }
        }
    }
}
