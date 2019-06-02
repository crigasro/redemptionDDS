using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleDoor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D colData) {
        if (colData.gameObject.CompareTag("Player"))
        {
            GameManager.instance.LoadNextScenario(6);
        }
    }
    
}
