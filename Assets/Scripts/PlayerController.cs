using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    public bool grounded;

    void Start()
    {
        grounded = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Vector2.zero;

        GetInputRight();
        GetInputLeft();
        //GetInputUp();
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    private void GetInputRight()
    {
        //direction = Vector2.zero;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }
        
    }

    private void GetInputLeft()
    {
        //direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }
    }

}
