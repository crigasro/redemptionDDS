using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInvState : DebuffState
{
    public ControlInvState(PlayerState player) : base(player){}

    public override void Tick()
    {
        StartCoroutine(InvertControl());
        player.SetState(new NoBadState(player));
        
    }

    IEnumerator InvertControl()
    {
        player.GetComponent<PlayerController>().speed *= -1f;
        yield return new WaitForSeconds(3);
        player.GetComponent<PlayerController>().speed *= -1f;
    }

    public override void OnStateEnter()
    {
        player.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public override void OnStateExit()
    {
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
