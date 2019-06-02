using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementSystem : Observer
{
    private FirstChest tutorialChest;
    private PotionAchivement pachiv;
    public GameObject achivementText;
    void Start()
    {
        tutorialChest = FindObjectOfType<FirstChest>();
        tutorialChest.AttachObserver(this);
        
        pachiv = FindObjectOfType<PotionAchivement>();
        pachiv.AttachObserver(this);
    }
    public override void OnNotify(GameObject go, NotifType nt, bool extraInfo)
    {   
        if(nt == NotifType.AchivementUnlocked)
            UnlockAchivement();
    }
    private void UnlockAchivement()
    {
        achivementText.gameObject.SetActive(true);
        StartCoroutine(waitTime());
        achivementText.gameObject.SetActive(false);
    }
    IEnumerator waitTime() { yield return new WaitForSeconds(3); }
}

public enum NotifType {
    ActivatedDoor,
    AchivementUnlocked 
}


