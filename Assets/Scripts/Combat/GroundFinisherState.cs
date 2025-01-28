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
        duration = 0.38f;
        animator.SetTrigger("Attack" + attackIndex);
        PlayerMovement.playerInstance.AttackStep();
        PlayerMovement.playerInstance.animationLock = true;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
             PlayerMovement.playerInstance.animationLock = false;
             stateMachine.SetNextStateToMain();
        }
    }
}
