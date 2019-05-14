using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    void Start()
    {
        grounded = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Vector2.zero;
        cunrrentPlayer = true;
        GetInputRight();
        GetInputLeft();
        Jump();
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

}
