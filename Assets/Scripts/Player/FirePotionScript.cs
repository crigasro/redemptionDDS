using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotionScript : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D (Collider2D collider) {
        Debug.Log("Collision by fireball");
        Destroy(gameObject);
    }
}
