using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    // Para saber si una puerta está abierta o no 
    // (= puedes pasar o no, aunque puedas caminar por ella)
    // Habrá que hacer uno para cada cosa que queramos mirar su estado
    protected enum EntityST { Open, Closed }

    public virtual void UpdateState() {}

    // Habrá un método para cada cosa, 
    // por ejemplo para el comportamiento de los objetos de los cofres o para enemigos
    protected void DoorAction (EntityST door, int actualLevel) {
        switch(door) {
            case EntityST.Open:
                // Animacion de puerta abierta (activar el parametro trigueador)

                // Al LoadDoorScenario le pasamos actualLevel, 
                // para que cargue el esenario que sigue al escenario donde está la puerta
                // actualLevel = el escenario donde está la puerta

                int nextLevel = actualLevel + 1;    // Cuidado con el orden en el que se ponen las escenas
                GameManager.instance.LoadDoorScenario(nextLevel);
                break;

            case EntityST.Closed:
                // Nada
                break;
        }
    }

    protected void ChestAction (EntityST chest) {
        switch(chest) {
            case EntityST.Open:
                // Poner la animación del cofre abierto (poner ese trigger a true)
                // Llamar al método para que el cofre te de algo
                break;

            case EntityST.Closed:
                // Trigger de cofre cerrado para la animación (aunque seguramente esto no se use)
                break;
        }
    }
}
