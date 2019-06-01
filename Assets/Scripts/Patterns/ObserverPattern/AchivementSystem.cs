using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementSystem : Observer
{
    public override void OnNotify(Object obj, Event ev)
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
