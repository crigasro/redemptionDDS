using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IBasePotion
{ 
    public void Use() {
        Debug.Log("Use() of Potion");
        Destroy(gameObject);
    }

    protected void Start () {
        Debug.Log("Potion initialized");
    }
}
