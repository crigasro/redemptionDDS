using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleDoor : MonoBehaviour
{
    void OnTriggerEnter2D(GameObject other) {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.LoadNextScenario(6);
        }
    }
    
}
