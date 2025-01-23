using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{

    private StateMachine meleeStateMachine;
    [SerializeField] public Animator animator;

    PlayerDash playerDash;

    [SerializeField] public Collider2D hitbox;
    //[SerializeField] public GameObject Hiteffect;

    void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();
        //animator = GetComponent<Animator>();
        playerDash = GetComponent<PlayerDash>();
        
    }

    void Update()
    {
        if (animator.GetFloat("AttackWindow.Open") == 0f && Input.GetMouseButtonDown(0) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState) && !playerDash.boolDashComboFix)
        {
            meleeStateMachine.SetNextState(new GroundEntryState());
        }
    }
}
