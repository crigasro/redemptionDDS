using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotionScript : MonoBehaviour
{
    public float speed;
    public Vector3 forceDir;

    IAttack attackData;



    public Rigidbody2D rb;

    private float startTime;

    void Start()
    {
        attackData = new BaseAttack();
        if (GameManager.instance.firePower)
            attackData = new FireAttack(attackData);
        if (GameManager.instance.icePower)
            attackData = new IceAttack(attackData);

        attackData.OnSpawn(gameObject);


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
        rb.AddForce(forceDir * speed * Time.deltaTime);

        if (Time.time >= (startTime + 2f))
            Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D collider) {

        if (collider.gameObject.tag == "Essential" || collider.gameObject.tag == "Player")
            return;

        attackData.OnLand(gameObject, collider);
    }
}
