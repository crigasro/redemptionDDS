using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowedState : DebuffState
{
     public SlowedState(PlayerState player) : base(player){}

    public override void Tick()
    {
        StartCoroutine(SlowCharacter());
        player.SetState(new NoBadState(player));
    }

    IEnumerator SlowCharacter()
    {
        float anterior = player.GetComponent<PlayerController>().speed;
        player.GetComponent<PlayerController>().speed = anterior/3;
        yield return new WaitForSeconds(3);
        player.GetComponent<PlayerController>().speed = anterior;
    }

    public override void OnStateEnter()
    {
        player.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public override void OnStateExit()
    {
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
