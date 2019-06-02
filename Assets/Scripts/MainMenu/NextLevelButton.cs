using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void ClickToNext(){
        int buildSettingsIndex = SceneManager.GetActiveScene().buildIndex;
        GameManager.instance.LoadNextScenario(buildSettingsIndex);
    }
}
