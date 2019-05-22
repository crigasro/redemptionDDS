using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianController : Character
{
    // Start is called before the first frame update
    void Start()
    {
        //cunrrentPlayer = false;
        grounded = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
