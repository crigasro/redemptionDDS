using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotionAchivement : Subject
{
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3 && GameManager.instance.firePower)
        {
            NotifyObserver(NotifType.AchivementUnlocked, true);
        }
        if(SceneManager.GetActiveScene().buildIndex == 4 && GameManager.instance.icePower)
        {
            NotifyObserver(NotifType.AchivementUnlocked, true);
        }
        if(SceneManager.GetActiveScene().buildIndex == 5 && GameManager.instance.lifePower)
        {
            NotifyObserver(NotifType.AchivementUnlocked, true);
        }
    }
}
