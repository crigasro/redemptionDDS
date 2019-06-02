using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackDecorator : IAttack
{
    private IAttack _attack;
    protected List<string> ignoreTags = new List<string>();
    public Vector3 offset = new Vector2(0.25f, 0.25f); 

    public AttackDecorator(IAttack attack)
    {
        this._attack = attack;
    }

    public virtual void OnSpawn(GameObject projectile)
    {
        this._attack.OnSpawn(projectile);
    }
    public virtual void OnLand(GameObject projectile, Collider2D collisionData)
    {
        this._attack.OnLand(projectile, collisionData);
    }

    public void DoEffect(GameObject effect, GameObject projectile)
    {
        GameObject.Instantiate(effect, projectile.transform.position, Quaternion.identity);
        GameObject.Instantiate(effect, projectile.transform.position + offset, Quaternion.identity);
        GameObject.Instantiate(effect, projectile.transform.position - offset, Quaternion.identity);
    }

}