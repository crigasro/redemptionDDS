using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivementSystem : Observer
{
    private FirstChest tutorialChest;
    private PotionAchivement pachiv;

    private bool unlocked;

    void Start()
    {
        tutorialChest = FindObjectOfType<FirstChest>();
        if (tutorialChest != null)
            tutorialChest.AttachObserver(this);
        
        
        pachiv = FindObjectOfType<PotionAchivement>();
        if (pachiv != null)
            pachiv.AttachObserver(this);
    }
    public override void OnNotify(GameObject go, NotifType nt, bool extraInfo)
    {   
        if(nt == NotifType.AchivementUnlocked)
            UnlockAchivement();
    }
    private void UnlockAchivement()
    {
        Debug.Log("UnlockAchivement");
        if (unlocked) return;

        unlocked = true;
        StartCoroutine(waitTime());
    }
    IEnumerator waitTime() {
        GameObject.Find("AchivementUnlocked").transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(3);
        GameObject.Find("AchivementUnlocked").transform.localScale = new Vector3(0, 0, 0);
    }
}

public enum NotifType {
    ActivatedDoor,
    AchivementUnlocked 
}


