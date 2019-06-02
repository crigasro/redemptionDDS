using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotionScript : MonoBehaviour
{
    public float speed;
    public GameObject explosionEffect;
    public GameObject noEffect;
    public Vector3 forceDir;



    public Rigidbody2D rb;

    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;

        Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPos.z = 0;

        forceDir = aimPos - transform.position;
        forceDir = forceDir.normalized;

        float angle = Mathf.Atan2(forceDir.y, forceDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update()
    {
        Debug.Log(forceDir * speed * Time.deltaTime);
        rb.AddForce(forceDir * speed * Time.deltaTime);

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
