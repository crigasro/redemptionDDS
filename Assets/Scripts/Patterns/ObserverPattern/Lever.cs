using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Subject
{
    public Animator anim;
    private bool isActive = false, canUseLever;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        UseLevel();
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        canUseLever = true;
    }

    public void OnTriggerStay2D(Collider2D other) 
    {
        canUseLever = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        canUseLever = false;
    }

    public void UseLevel()
    {
        if(Input.GetKeyDown(KeyCode.E) && canUseLever)
        {
            if(isActive) {
                anim.SetBool("activeLever", false);
                isActive = false;
                NotifyObserver(NotifType.ActivatedDoor, false);
            } else {
                anim.SetBool("activeLever", true);
                isActive = true;
                NotifyObserver(NotifType.ActivatedDoor, true);
            }
        }
    }
}
