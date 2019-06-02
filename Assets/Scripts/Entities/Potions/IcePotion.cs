using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePotion : Potion
{
    protected override void Use(GameObject player)
    {
        GameManager.instance.giveIce();
    }
}
