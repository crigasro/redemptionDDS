using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Subject
{
    public static Lever instance;
    public Animator anim;
    private bool isActive = false;

    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        UseLevel();
    }

    public void OnTriggerStay2D(Collider2D other) 
    {
        UseLevel();
    }

    public void UseLevel()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isActive) {
                anim.SetBool("activeLever", false);
                isActive = false;
                controller.GetComponent<LeverPuzzle>().ReceiveLeverSignal(gameObject, false);
            } else {
                anim.SetBool("activeLever", true);
                isActive = true;
                controller.GetComponent<LeverPuzzle>().ReceiveLeverSignal(gameObject, false);
            }
        }
    }
}
