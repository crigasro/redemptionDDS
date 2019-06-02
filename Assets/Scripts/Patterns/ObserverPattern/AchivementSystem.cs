using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementSystem : Observer
{
    private FirstChest tutorialChest;
    void Start()
    {
        tutorialChest = FindObjectOfType<FirstChest>();
        tutorialChest.AttachObserver(this);
    }
    public override void OnNotify(GameObject go, NotifType nt, bool extraInfo)
    {   
        
        switch(nt)
        {
            case NotifType.OpenedTutorialChest:
                UnlockChestAchivement();
                tutorialChest.DetachObserver(this);
                break;
            case NotifType.GotFirePotion:
                
                break; 
            case NotifType.GotIcePotion:

                break;
            case NotifType.GotLifePotion:

                break;
        }
        
    }

    private void UnlockChestAchivement()
    {
        GameObject achivementText = GameObject.FindWithTag("AchivementChest");
        achivementText.SetActive(true);
        StartCoroutine(waitTime());
        achivementText.SetActive(false);
    }

    private void UnlockFireAchivement()
    {

    }
    private void UnlockIceAchivement()
    {

    }
    private void UnlockLifeAchivement()
    {

    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(3);
    }
}

public enum NotifType {
    ActivatedDoor, GeneralMessage, 
    OpenedTutorialChest, GotFirePotion, GotIcePotion, GotLifePotion 
}


