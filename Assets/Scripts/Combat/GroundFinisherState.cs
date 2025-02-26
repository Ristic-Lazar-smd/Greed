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
        duration = 0.57f;
        weaponAnimator.SetTrigger("Attack" + attackIndex);
        playerAnimator.SetTrigger("Attack" + attackIndex);
        meleeMain.UpdateAttackDirection();
        //attackStep.Step();
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
