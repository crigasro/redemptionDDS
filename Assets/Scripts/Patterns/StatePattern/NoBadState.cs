using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBadState : DebuffState
{
    public NoBadState(PlayerState player) : base(player){}

    public override void Tick()
    {
        int nextState = GameManager.instance.getGoingState();
        switch(nextState) 
        {
            case 0:
                //Debug.Log("Todo normal por aquí");
                break;
            case 1:
                Debug.Log("Gravedad invertida");
                GameManager.instance.setGoingState(0);
                player.SetState(new GravityInvState(player));
                break;
            case 2:
                Debug.Log("Controles invertidos");
                GameManager.instance.setGoingState(0);
                player.SetState(new ControlInvState(player));
                break;
            case 3:
                Debug.Log("Personaje ralentizado");
                GameManager.instance.setGoingState(0);
                player.SetState(new SlowedState(player));
                break;
        }
        
    }

}
