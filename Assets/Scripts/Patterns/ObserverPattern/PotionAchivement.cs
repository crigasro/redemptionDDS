using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotionAchivement : Subject
{
    void Update()
    {
        if (CanUnlockAchivement())
            NotifyObserver(NotifType.AchivementUnlocked, true);
    }

    bool CanUnlockAchivement()
    {
        int bIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(bIndex + " firepower: " + GameManager.instance.firePower);
        bool achivementA = bIndex == 3 && GameManager.instance.firePower;
        bool achivementB = bIndex == 4 && GameManager.instance.icePower;
        bool achivementC = bIndex == 5 && GameManager.instance.lifePower;

        return achivementA || achivementB || achivementC;
    }
}
