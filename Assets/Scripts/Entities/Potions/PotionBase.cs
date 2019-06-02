using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    virtual protected void Use(GameObject player) { }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Use(other.gameObject);
            Destroy(gameObject);
        }
    }
}
