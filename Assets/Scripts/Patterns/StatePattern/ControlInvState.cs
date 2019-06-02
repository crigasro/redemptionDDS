using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInvState : DebuffState
{
    public ControlInvState(PlayerState player) : base(player){}

    public override void Tick()
    {
        if (Time.time >= startTime + 3) {
            player.SetState(new NoBadState(player));
        }
    }

    public override void OnStateEnter()
    {
        player.GetComponent<PlayerController>().speed *= -1f;
        player.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public override void OnStateExit()
    {
        player.GetComponent<PlayerController>().speed *= -1f;
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
