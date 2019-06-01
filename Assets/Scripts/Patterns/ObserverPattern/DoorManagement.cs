using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManagement : Observer
{
    // Como la puerta espera a que pase algo (que se resuelva el puzzle por ejemplo en el castillo)
    // es un observador
    public Animator animDoor;
    private bool openDoor = false;
    void Start()
    {
        animDoor = GetComponent<Animator>();
    }

    public override void OnNotify(Object obj, Event ev)
    {
        // Comprobar que el evento es el que nos interesa if(ev blablabla)
        animDoor.SetBool("activeDoor", true);
        openDoor = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && openDoor) 
            GameManager.instance.LoadDoorScenario(SceneManager.GetActiveScene().buildIndex);
    }
}
