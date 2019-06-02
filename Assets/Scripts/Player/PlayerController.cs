using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float direction;
    private Animator anim;
    public float speed;
    public Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Disparación de bola de fuego
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(AssetManager.instance.ProjectilePrefab, GameManager.instance.firePoint.position, Quaternion.identity); 
    }
    void FixedUpdate() {
        
        //Y puede que aquí
        Move();
        anim.SetFloat("x", direction);
    }

    private void Move() 
    {
         direction = Input.GetAxis("Horizontal");
         rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }

    
}
