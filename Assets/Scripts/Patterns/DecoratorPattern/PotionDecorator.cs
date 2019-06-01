using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionDecorator : MonoBehaviour, IBasePotion
{
    public Potion potion;

    public PotionDecorator (Potion p) {
        this.potion = p;
    }
    public void Use() {
        this.potion.Use();  //El Use() de Potion
        Debug.Log("Use() of PotionDecorator");
    }
}
