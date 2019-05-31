using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    // Para saber si una puerta está abierta o no 
    // (= puedes pasar o no, aunque puedas caminar por ella)
    // Habrá que hacer uno para cada cosa que queramos mirar su estado
    protected enum DoorST {
        Open,
        Closed
    }

    public virtual void UpdateState() {}

    // Habrá un método para cada cosa, 
    // por ejemplo para el comportamiento de los objetos de los cofres o para enemigos
    protected void DoorAction (DoorST door, string level) {
        switch(door) {
            case DoorST.Open:

                break;

            case DoorST.Closed:

                break;
        }
    }
}
