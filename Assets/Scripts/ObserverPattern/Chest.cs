using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Subject
{
    private string _chestState;
    public string ChestState {
        get {return _chestState; }
        set { _chestState = value; }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Jugador frente a cofre");
        }
    }
}
