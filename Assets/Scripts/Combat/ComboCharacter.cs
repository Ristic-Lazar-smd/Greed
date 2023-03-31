using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{

    private StateMachine meleeStateMachine;
    private Animator animator;

    PlayerDash playerDash;

    [SerializeField] public Collider2D hitbox;
    //[SerializeField] public GameObject Hiteffect;

    // Start is called before the first frame update
    void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();
        animator = GetComponent<Animator>();
        playerDash = GetComponent<PlayerDash>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetFloat("AttackWindow.Open") == 0f && Input.GetMouseButtonDown(0) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState) && !playerDash.boolDashComboFix)
        {
            //ovo nije problem
            meleeStateMachine.SetNextState(new GroundEntryState());
        }
    }
}
