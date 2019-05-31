using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : BasePotion
{
    public override void Use() {
        Debug.Log("Potion consumed");
        Destroy(gameObject);
    }

    protected void Start () {
        Debug.Log("Potion initialized");
    }

    protected void Update() {
        if (Input.GetKey(KeyCode.E)) {
            Use();
        }
    }
}
