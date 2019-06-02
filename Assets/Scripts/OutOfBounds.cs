using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private SpawnPoint sp;

    void Start()
    {
        sp = FindObjectOfType<SpawnPoint>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) 
        {
            other.transform.position = sp.transform.position;
        }
    }
}
