using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private DebuffState currentState;
    
    void Start() 
    {
        SetState(new NoBadState(this));
    }
    
    void Update() { 
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
}
