﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstChest : Subject
{
    private Animator animChest;
    private bool inChest;

    void Start() {
        animChest = GetComponent<Animator>();
    }

    void Update() {
        OpenChest();
    }


    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") ){
            inChest = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") ){
            inChest = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") ){
            inChest = false;
        }
    }

    private void OpenChest() {
        if(Input.GetKeyDown(KeyCode.E) && inChest) {
            animChest.SetBool("chestIsOpen", true);
            //GameManager.instance.GiveRandomObjectFromChest();
            NotifyObserver(NotifType.AchivementUnlocked, true);
        }
    }
}
