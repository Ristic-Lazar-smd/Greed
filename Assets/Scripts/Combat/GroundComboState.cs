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
        duration = 0.40f;
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
            if (shouldCombo)
            {
                //stateMachine.SetNextState(new GroundFinisherState());
                shouldCombo = false;
                //privremeno dok ne ubacim 3. hit u combo
                stateMachine.SetNextStateToMain();
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }

        //attack delay combo, implementirano, samo cekam animaciju, 
        /*if(fixedtime<duration-windowOfAttack && Input.GetMouseButtonDown(0)){
            flag = true;
        }    
        if (!flag && fixedtime >= duration-windowOfAttack && fixedtime <= duration ){

            if (Input.GetMouseButtonDown(0)){
                stateMachine.SetNextState(new GroundDelayState());
                //ebug.Log("delayCombo");
                //stateMachine.SetNextStateToMain();
            }
        }*/
    }
}
