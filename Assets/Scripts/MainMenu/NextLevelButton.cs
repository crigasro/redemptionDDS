using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    void Update()
    {
        ActivateMenu();
    }
    public void ClickToNext(){
        int buildSettingsIndex = SceneManager.GetActiveScene().buildIndex;
        GameManager.instance.LoadNextScenario(buildSettingsIndex);
    }

    public void ActivateMenu() // Para refactorizar
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 3: transform.Find("AAAAAAA").gameObject.SetActive(GameManager.instance.firePower); break;
            case 4: transform.Find("GotPotionMenu").gameObject.SetActive(GameManager.instance.icePower); break;
            case 5: transform.Find("EEEEEE").gameObject.SetActive(GameManager.instance.lifePower); break;
        }
    }
}
