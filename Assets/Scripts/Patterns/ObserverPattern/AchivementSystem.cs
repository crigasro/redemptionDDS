using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementSystem : Observer
{
    private FirstChest tutorialChest;
    public GameObject achivementText;
    void Start()
    {
        tutorialChest = FindObjectOfType<FirstChest>();
        tutorialChest.AttachObserver(this);
    }
    public override void OnNotify(GameObject go, NotifType nt, bool extraInfo)
    {   
        if(nt == NotifType.AchivementUnlocked)
            UnlockAchivement();
    }

    private void UnlockAchivement()
    {
        //GameObject achivementText = GameObject.FindWithTag("AchivementChest");
        Debug.Log("Has llegado al unnlocked");
        achivementText.gameObject.SetActive(true);
        StartCoroutine(waitTime());
        achivementText.gameObject.SetActive(false);
    }
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Esperados 3 segundos");
    }
}

public enum NotifType {
    ActivatedDoor, GeneralMessage, 
    AchivementUnlocked 
}


