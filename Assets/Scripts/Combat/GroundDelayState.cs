using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDelayState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        //Attack
        attackIndex = 4;
        duration = 0.58f;
        weaponAnimator.SetTrigger("Attack" + attackIndex);
        PlayerMovement.playerInstance.animationLock = true;
        meleeMain.UpdateAttackDirection();
        attackStep.Step();
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
