using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementSystem : Observer
{
    public override void OnNotify(GameObject go, NotifType nt, bool extraInfo)
    {   
        /*
        switch(ev)
        {
            case Event.OpenedTutorialChest:
            break;
        }
         */
    }

    private void UnlockAchivement()
    {

    }
}

public enum NotifType {
    AchivementUnlocked, ActivatedDoor, GeneralMessage
}
