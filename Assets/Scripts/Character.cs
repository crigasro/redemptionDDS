using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private float speed = 175f;
    protected Vector2 direction;

    protected bool cunrrentPlayer;
    public bool grounded;
    protected Animator animator;
    protected Rigidbody2D rb;
    [Range(1, 100)]
    public float jumpVelocity;

    void Start()
    {

    }

    //FixedUpdate porque es mejor para movimientos
    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected void Move()
    {
        //transform.Translate(direction * speed * Time.deltaTime);
        rb.velocity = direction * speed * Time.deltaTime;
        AnimCharacter(direction);
    }

    public void AnimCharacter(Vector2 direction)
    {
        float xValue = direction.x;
        animator.SetFloat("x", xValue);
        //animator.SetFloat("y", direction.y);

        animator.SetBool("isMoving", direction != Vector2.zero);
    }

    protected void GetInputRight()
    {
        //direction = Vector2.zero;
        bool keyPressed = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));

        if (keyPressed && cunrrentPlayer)
        {
            direction += Vector2.right;
        }
        
    }

    protected void GetInputLeft()
    {
        //direction = Vector2.zero;
        bool keyPressed = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        if (keyPressed && cunrrentPlayer)
        {
            direction += Vector2.left;
        }
    }

    protected void Jump()
    {
        bool condition = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && grounded;
        if (condition && cunrrentPlayer)
        {
            direction += Vector2.up;
        }
    }
}
