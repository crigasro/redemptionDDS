using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private float speed = 175f;
    protected Vector2 direction;

    public bool grounded;
    protected Animator animator;
    protected Rigidbody2D rb;

    public bool isActive { get; set; }

    [Range(1, 100)]
    public float jumpVelocity;

    void Start()
    {

    }

    //FixedUpdate porque es mejor para movimientos
    protected virtual void FixedUpdate()
    {
        if (isActive)
            Move();
    }

    protected void Move()
    {
        rb.velocity = direction * speed * Time.fixedDeltaTime;
        AnimCharacter(direction);
    }

    public void AnimCharacter(Vector2 direction)
    {
        float xValue = direction.x;
        animator.SetFloat("x", xValue);

        animator.SetBool("isMoving", direction != Vector2.zero);
    }

    protected void GetInputRight()
    {
        bool keyPressed = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));

        if (keyPressed)
        {
            direction += Vector2.right;
        }
        
    }

    protected void GetInputLeft()
    {
        bool keyPressed = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        if (keyPressed)
        {
            direction += Vector2.left;
        }
    }

    protected void GetInputJump()
    {
        bool condition = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && grounded;
        if (condition)
        {
            direction += Vector2.up;
        }
    }

    protected void Jump()
    {
//        if (grounded && isActive)

    }
}
