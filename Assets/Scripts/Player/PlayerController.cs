using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    private Animator anim;

    //public GameManager instance;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        //Hacer muchas refactorizaciones aquí -- Lo estoy haciendo muy guarro
        Vector2 moveInput =  new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        //Disparación de bola de fuego
        if (Input.GetKeyDown(KeyCode.G) && GameManager.instance.icePower) {
            Instantiate(GameManager.instance.iceball, GameManager.instance.firePoint.position, GameManager.instance.firePoint.rotation);
        }

        //Disparación de bola de fuego
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.firePower) {
            Instantiate(GameManager.instance.fireball, GameManager.instance.firePoint.position, GameManager.instance.firePoint.rotation);
        }
    }
    void FixedUpdate() {
        //Y puede que aquí
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        anim.SetFloat("x", moveVelocity.x);
    }
}
