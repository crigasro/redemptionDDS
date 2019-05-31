using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : State
{
    public int PlaceToLoad;
    private EntityST doorMode = EntityST.Closed;

    public override void UpdateState() {}
    private void OnTriggerEnter2D(Collider2D player) {
        switch(doorMode) {
            case EntityST.Closed:
                if(player.CompareTag("Player"))
                {
                    doorMode = EntityST.Open;
                    int actualLevel = SceneManager.GetActiveScene().buildIndex;
                    DoorAction(doorMode, actualLevel);
                }
                break;
        }
    }
}
