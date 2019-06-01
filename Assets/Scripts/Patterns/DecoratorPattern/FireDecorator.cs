using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDecorator : PotionDecorator
{
    public FireDecorator (Potion p) :  base(p) {
    }

    public new void Use () {
        base.Use(); //Utiliza el Use() de PotionDecorator
        Debug.Log("Use() of FireDecorator");
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            GameManager.instance.giveFire();
            Use();
        }
    }
}
