using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvisibleWallToPass : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player"))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            GameManager.instance.LoadNextScenario(index);
        }
    }
}
