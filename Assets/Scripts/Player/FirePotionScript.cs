using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotionScript : MonoBehaviour
{
    public float speed;
    public GameObject explosionEffect;
    public GameObject noEffect;
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
        if (collider.gameObject.tag != "Essential") {
           Destroy(collider.gameObject);
           Instantiate(explosionEffect, collider.gameObject.transform.position, Quaternion.identity);
        } else {
            Instantiate(noEffect, collider.gameObject.transform.position, Quaternion.identity);
        }
    }
}
