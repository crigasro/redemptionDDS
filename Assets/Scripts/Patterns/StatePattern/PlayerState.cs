using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private DebuffState currentState;

    public Rigidbody2D rb;
    /* 
    public DebuffState actualState;
    public DebuffState slowedState;
    public DebuffState controlInvState;
    public DebuffState gravityInvState;
    public DebuffState noBadState;
    */
    
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        SetState(new NoBadState(this));
    }
    
    void Update() {
        //doEffect(); 
        currentState.Tick();
    }

    public void SetState(DebuffState state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;
            
        if (currentState != null)
            currentState.OnStateExit();    
    }

    /*
    public PlayerState() 
    {
        slowedState = new SlowedState();
        controlInvState = new ControlInvState();
        gravityInvState = new GravityInvState();
        noBadState = new NoBadState();

        actualState = noBadState;
    }

    public void doEffect() 
    {
        actualState.debuffEffect(rb);
    }

    public void changeState(DebuffState debuff) 
    {
        actualState = debuff;
    }

    public DebuffState getSlowerState() 
    {
        return slowedState;
    }

    public DebuffState getControlInvState() 
    {
        return controlInvState;
    }

    public DebuffState getGravityInvState() 
    {
        return gravityInvState;
    }

    public DebuffState getNormalState() 
    {
        return noBadState;
    }
     */
    
}
