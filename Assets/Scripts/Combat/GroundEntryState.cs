using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        //Attack
        attackIndex = 1;
        duration = 0.3f;
        animator.SetTrigger("Attack" + attackIndex);
        PlayerMovement.playerInstance.AttackStep();
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
            }
        }
    }
}
