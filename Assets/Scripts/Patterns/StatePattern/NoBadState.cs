using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBadState : DebuffState
{
    public NoBadState(PlayerState player) : base(player){}

    public override void Tick()
    {
        
        Debug.Log("Todo normal por aquí");
    }

}
