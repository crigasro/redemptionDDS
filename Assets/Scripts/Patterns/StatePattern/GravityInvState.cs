using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInvState : DebuffState
{
    public GravityInvState(PlayerState player) : base(player){}

    public override void Tick()
    {
        if (Time.time >= startTime + 3) {
            player.SetState(new NoBadState(player));
        }
    }

    public override void OnStateEnter()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = -9f;
        player.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public override void OnStateExit()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 100f;
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
