using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDecorator : PotionDecorator
{
    public IceDecorator (Potion p) :  base(p) {
    }

    public new void Use () {
        base.Use(); //Utiliza el Use() de PotionDecorator
        Debug.Log("Use() of iceDecorator");
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            GameManager.instance.giveIce();
            Use();
        }
    }
}
