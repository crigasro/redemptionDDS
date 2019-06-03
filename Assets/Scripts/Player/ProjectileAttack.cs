using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public float speed;
    public Vector3 forceDir;

    IAttack attackData;



    public Rigidbody2D rb;

    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;

        SetupForceMovement();
        RotateToMouse();
        SetupAttackData();

        attackData.OnSpawn(gameObject);
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

        GameObject.Destroy(gameObject);
    }

    void SetupAttackData()
    {
        attackData = new BaseAttack();
        if (GameManager.instance.icePower)
            attackData = new IceAttack(attackData);
        if (GameManager.instance.firePower)
            attackData = new FireAttack(attackData);
    }
    void SetupForceMovement()
    {
        Vector3 aimPos;
        if (Camera.main == null)
            aimPos = transform.position;
        else
            aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPos.z = 0;

        forceDir = aimPos - transform.position;
        forceDir = forceDir.normalized;
    }

    void RotateToMouse()
    {
        float angle = Mathf.Atan2(forceDir.y, forceDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
