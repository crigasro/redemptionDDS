using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void OnSpawn(GameObject projectile);
    void OnLand(GameObject projectile, Collider2D collisionData);
}

public class BaseAttack : IAttack
{
    public void OnSpawn(GameObject projectile) {
        Debug.Log("Spawned Base Attack!");
    }
    public void OnLand(GameObject projectile, Collider2D collisionData)
    {
        Debug.Log("Landed base attack!");
    }

}
