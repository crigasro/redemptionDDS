using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;

    public Transform firePoint;
    public GameObject fireball;


    public bool firePower = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        //Hacer muchas refactorizaciones aquí -- Lo estoy haciendo muy guarro
        Vector2 moveInput =  new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        //Poción de fuego
        if (Input.GetKeyDown(KeyCode.Q)) {
            firePower = !firePower;
            Debug.Log("firePower is: " + firePower);
        }
        //Disparación de bola de fuego
        if (Input.GetKeyDown(KeyCode.Space) && firePower) {
            Instantiate(fireball, firePoint.position, firePoint.rotation);
        }
    }

    public void giveFire() {
        firePower = true;
        Debug.Log("giveFire() -- firePower is: " + firePower);
    }

    void FixedUpdate() {
        //Y puede que aquí
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
