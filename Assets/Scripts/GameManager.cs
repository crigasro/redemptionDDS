using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerObj;

    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void LoadScenario(int buildSettingsIndex) {
        SceneManager.LoadScene(buildSettingsIndex);
    }

    public void LoadDoorScenario(int actualLevel) {
        SceneManager.LoadScene(actualLevel + 1);
    }
}
