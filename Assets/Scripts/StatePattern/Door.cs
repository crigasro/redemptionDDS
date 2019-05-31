using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : State
{
    public int PlaceToLoad;
    private DoorST doorMode = DoorST.Closed;

    public override void UpdateState() {}
    private void OnTriggerEnter2D(Collider2D player) {
        if(player.CompareTag("Player"))
        {
            doorMode = DoorST.Open;
            int actualLevel = SceneManager.GetActiveScene().buildIndex;
            DoorAction(doorMode, actualLevel);
        }
    }
}
