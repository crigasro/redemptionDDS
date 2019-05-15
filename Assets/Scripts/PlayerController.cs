using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    void Start()
    {
        isActive = true; // DE MOMENTO
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Vector2.zero;

        GetInputRight();
        GetInputLeft();
        GetInputJump();
    }


    protected override void FixedUpdate()
    {
        Debug.Log("fixedUpdate pc");
        base.FixedUpdate();
    }

}
