using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBadState : DebuffState
{
    public NoBadState(PlayerState player) : base(player){}

    public override void Tick()
    {
        GameManager.PlayerStates nextState = GameManager.instance.getGoingState();
        switch(nextState) 
        {
            case GameManager.PlayerStates.NoBadState:
                //Debug.Log("Ningún estado a aplicar");
                break;
            case GameManager.PlayerStates.GravityInvState:
                Debug.Log("Gravedad invertida");
                GameManager.instance.setGoingState(GameManager.PlayerStates.NoBadState);
                player.SetState(new GravityInvState(player));
                break;
            case GameManager.PlayerStates.ControlInvState:
                Debug.Log("Controles invertidos");
                GameManager.instance.setGoingState(GameManager.PlayerStates.NoBadState);
                player.SetState(new ControlInvState(player));
                break;
            case GameManager.PlayerStates.SlowedState:
                Debug.Log("Personaje ralentizado");
                GameManager.instance.setGoingState(GameManager.PlayerStates.NoBadState);
                player.SetState(new SlowedState(player));
                break;
        }
        
    }

}
