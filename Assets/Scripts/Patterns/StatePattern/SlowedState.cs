using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowedState : DebuffState
{
    private float anterior;

     public SlowedState(PlayerState player) : base(player){}

    public override void Tick()
    {
        if (Time.time >= startTime + 3) {
            player.SetState(new NoBadState(player));
        }
    }

    public override void OnStateEnter()
    {
        anterior = player.GetComponent<PlayerController>().speed;
        player.GetComponent<PlayerController>().speed = anterior/3;
        player.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public override void OnStateExit()
    {
        player.GetComponent<PlayerController>().speed = anterior;
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
