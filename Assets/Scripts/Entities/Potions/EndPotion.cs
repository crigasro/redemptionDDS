using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPotion : Potion
{
    protected override void Use(GameObject player)
    {
        GameManager.instance.giveLifePower();
    }
}
