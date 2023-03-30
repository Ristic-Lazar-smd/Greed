using UnityEngine;

public class StateMachine : MonoBehaviour
{
    PlayerDash playerDash;
    public string customName;

    private State mainStateType;

    public State CurrentState { get; private set; }
    private State nextState;

    // Update is called once per frame
    void Update()
    {
        if (nextState != null)
        {
            SetState(nextState);
        }
        if (CurrentState != null)
            CurrentState.OnUpdate();
    }

    private void SetState(State _newState)
    {
        nextState = null;
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }
        CurrentState = _newState;
        CurrentState.OnEnter(this);
    }

    public void SetNextState(State _newState)
    {
        if (_newState != null)
        {
            nextState = _newState;
            //ovo zaustavlja dash nakog sto napad canceluje dash//
            playerDash.isDashing=false;
        }
    }

    private void LateUpdate()
    {
        if (CurrentState != null)
            CurrentState.OnLateUpdate();
    }

    private void FixedUpdate()
    {
        if (CurrentState != null)
            CurrentState.OnFixedUpdate();
    }

    public void SetNextStateToMain()
    {
        nextState = mainStateType;
    }

    private void Awake()
    {
        playerDash = GetComponent<PlayerDash>();
        if (mainStateType == null)
        {
            //if (customName == "Combat")
            //{
                mainStateType = new IdleCombatState();
           // }
        }
        SetNextStateToMain();
    }
}