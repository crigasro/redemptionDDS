using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private Animator anim;

    //public GameManager instance;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Disparación de bola de fuego
        if (Input.GetKeyDown(KeyCode.G))
            Instantiate(AssetManager.instance.ProjectilePrefab, GameManager.instance.firePoint.position, Quaternion.identity); 
    }
    void FixedUpdate() {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);
        //Y puede que aquí
        anim.SetFloat("x", move);
    }
}
