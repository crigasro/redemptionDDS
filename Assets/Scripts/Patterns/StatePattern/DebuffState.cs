using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DebuffState : MonoBehaviour
{
    protected PlayerState player;

    public abstract void Tick();

    public virtual void OnStateEnter() {}
    public virtual void OnStateExit() {}

    public DebuffState(PlayerState player) 
    {
        this.player = player;
    }

    //public abstract void debuffEffect(Rigidbody2D rigidbody);
   
}
