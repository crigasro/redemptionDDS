using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    // Para saber si una puerta está abierta o no 
    // (= puedes pasar o no, aunque puedas caminar por ella)
    // Habrá que hacer uno para cada cosa que queramos mirar su estado
    protected enum DoorST { Open, Closed }
    protected enum ChestST { Open, Closed }



    public virtual void UpdateState() {}

    // Habrá un método para cada cosa, 
    // por ejemplo para el comportamiento de los objetos de los cofres o para enemigos
    protected void DoorAction (DoorST door, string level) {
        switch(door) {
            case DoorST.Open:
                // Cargar el esenario con ese nombre (el string level = dirección donde está el escenario)
                break;

            case DoorST.Closed:

                break;
        }
    }

    protected void ChestAction (ChestST chest) {
        switch(chest) {
            case ChestST.Open:
                // Poner la animación del cofre abierto (poner ese trigger a true)
                // Llamar al método para que el cofre te de algo
                break;

            case ChestST.Closed:
                // Trigger de cofre cerrado para la animación (aunque seguramente esto no se use)
                break;
        }
    }
}
