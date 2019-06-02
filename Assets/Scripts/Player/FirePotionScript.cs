using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotionScript : MonoBehaviour
{
    public float speed;
    public GameObject explosionEffect;
    public GameObject noEffect;
    public Vector3 aimPos;
    public Transform target;


    public Rigidbody2D rb;

    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;

        aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPos.z = 0;
    }

    void Update()
    {
        Vector3 normalized = aimPos - transform.position;
        normalized = normalized.normalized;

        rb.AddForce(normalized * speed * Time.deltaTime);
        Debug.Log("normalized: " + normalized);

        //float angle = Mathf.Atan2(aimPos.y, aimPos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        if (Time.time >= (startTime + 2f))
            Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D collider) {

        if (collider.gameObject.tag == "Essential" || collider.gameObject.tag == "Player")
            return;

        if (collider.gameObject.tag == "Destroyable")
            Destroy(collider.gameObject);

        Instantiate(explosionEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
