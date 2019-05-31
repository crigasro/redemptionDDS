using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : State
{
    public int PlaceToLoad;

    public override void UpdateState() {
        
    }
    private void OnTriggerEnter2D(Collider2D player) {
        if(player.CompareTag("Player"))
        {
            UpdateState();
        }
    }
}
