using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        
        base.OnEnter(_stateMachine);

        //Attack
        attackIndex = 1;
        duration = 0.3f; //duration mora da bude framerate podeljeno sa broj frejmova
        animator.SetTrigger("Attack" + attackIndex);
        PlayerMovement.playerInstance.AttackStep();
        PlayerMovement.playerInstance.animationLock = true;
        
    }

    public override void OnUpdate()
    {
        
        base.OnUpdate();
        Debug.Log("1");

        if (fixedtime >= duration)
        {
            if (shouldCombo)
            {
                stateMachine.SetNextState(new GroundComboState());
            }
            else
            {
                stateMachine.SetNextStateToMain();
                PlayerMovement.playerInstance.animationLock = false;
            }
        }
    }
}
