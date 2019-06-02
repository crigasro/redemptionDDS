using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotion : Potion
{
    protected override void Use(GameObject player)
    {
        GameManager.instance.giveFire();
    }
}