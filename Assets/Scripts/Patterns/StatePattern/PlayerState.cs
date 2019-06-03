using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private DebuffState currentState;

    private void Awake()
    {
        currentState = new NoBadState(this);
    }
    void Start() 
    {
        SetState(new NoBadState(this));
    }
    
    void Update() {
        if (currentState != null)
        currentState.Tick();
    }

    public void SetState(DebuffState state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;
            
        if (currentState != null)
            currentState.OnStateEnter();    
    }    

    public DebuffState getState()
    {
        return currentState;
    }


}
