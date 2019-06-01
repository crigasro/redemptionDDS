using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DebuffState : MonoBehaviour
{
    //public Rigidbody2D rigidbody;
    public abstract void debuffEffect(Rigidbody2D rigidbody);
   
}
