﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManagement : Observer
{
    // Como la puerta espera a que pase algo 
    // (que se resuelva el puzzle por ejemplo en el castillo)
    // es un observador
    public Animator animDoor;
    private bool openDoor = false;

    public GameObject[] levers;
    private bool[] correctCombination = new bool[] {false, true, true};
    private bool[] playerCombination = new bool[3];

    void Start()
    {
        animDoor = GetComponent<Animator>();
        Lever.instance.AttachObserver(this);
    }

    public override void OnNotify(GameObject go, NotifType nt, bool leverstatus)
    {
        if(nt.Equals(NotifType.ActivatedDoor))
        {
            animDoor.SetBool("activeDoor", true);
            openDoor = true;
        }
        if(nt.Equals(NotifType.GeneralMessage))
        {
            ManageLeverNotification(go, leverstatus);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && openDoor) 
            GameManager.instance.LoadDoorScenario(SceneManager.GetActiveScene().buildIndex);
    }

    public void ManageLeverNotification(GameObject go, bool leverstatus)
    {
        for(int i = 0; i < 3; i++)
        {
            if(go == levers[i])
            {
                playerCombination[i] = leverstatus;
            }
        }
        TestCorrectCombination();
    }

    public void TestCorrectCombination()
    {
        bool isCorrect = true;
        for(int i = 0; i < 3; i++){
            if(playerCombination[i] != correctCombination[i])
            {
                isCorrect = false;
                Debug.Log("No es correcta la combinacion");
                return;
            }
        }
        if(isCorrect)
        {
            Debug.Log("COMBINACIÓN CORRECTA");
            openDoor = true;
        }
    }
}
