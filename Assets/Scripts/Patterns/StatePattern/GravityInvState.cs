using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInvState : DebuffState
{
    public GravityInvState(PlayerState player) : base(player){}

    public override void Tick()
    {
        StartCoroutine(ChangeGravity());
        player.SetState(new NoBadState(player));
    }

    IEnumerator ChangeGravity() 
    {
        player.GetComponent<Rigidbody2D>().gravityScale = -9f;
        yield return new WaitForSeconds(3);
        player.GetComponent<Rigidbody2D>().gravityScale = 100f;
    }

    public override void OnStateEnter()
    {
        player.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public override void OnStateExit()
    {
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
