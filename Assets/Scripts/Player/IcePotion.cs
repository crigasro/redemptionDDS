using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePotion : MonoBehaviour
{
    public float speedX, speedY;
    public GameObject iceEffect;
    public GameObject noEffect;
    void Start()
    {
        
    }
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(speedX * Time.deltaTime, speedY * Time.deltaTime), ForceMode2D.Impulse);
        
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        
        Debug.Log("Collision by iceball");
        Destroy(gameObject);
        if (collider.gameObject.tag == "Water")
        {
            Vector3 offset = new Vector3(0, 2f, 0f);
            Instantiate(iceEffect, collider.gameObject.transform.position + offset, Quaternion.identity);
            collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.5f);
            collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            collider.gameObject.GetComponent<BuoyancyEffector2D>().useColliderMask = false;
        } else {
            //Vector3 offset = new Vector3(1f, -1f, 0f);

            Instantiate(noEffect, collider.gameObject.transform.position, Quaternion.identity);
        }
    }
}
