using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private float speed = 175f;
    protected Vector2 direction;

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
        Jump();
    }

    protected void Jump()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
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
}
