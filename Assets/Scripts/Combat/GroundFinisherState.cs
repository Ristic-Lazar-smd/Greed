using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFinisherState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        //Attack
        attackIndex = 3;
        duration = 0.5f;
        animator.SetTrigger("Attack" + attackIndex);
        PlayerMovement.playerInstance.AttackStep();
        //PlayerMovement.playerInstance.animationLock = true;
    }

    public override void OnUpdate()
    {
        Debug.Log("3");
        base.OnUpdate();

        if (fixedtime >= duration)
        {
             PlayerMovement.playerInstance.animationLock = false;
             stateMachine.SetNextStateToMain();
        }
    }
}
