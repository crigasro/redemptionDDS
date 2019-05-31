using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotion : Potion
{
    void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F)) {
            Debug.Log ("Otorgar poder de fuego al jugador");
            base.Use();
        }
    }
}
