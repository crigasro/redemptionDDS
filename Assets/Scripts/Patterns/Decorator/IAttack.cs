using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void OnSpawn(GameObject projectile);
    void OnLand(Collision2D collisionData);
}

public abstract class AttackDecorator : IAttack
{
    private IAttack _attack;

    public AttackDecorator(IAttack attack)
    {
        this._attack = attack;
    }

    public virtual void OnSpawn(GameObject projectile) { }
    public virtual void OnLand(Collision2D collisionData) { }

}

public class FireAttack : AttackDecorator
{
    public FireAttack(IAttack attack) : base(attack)
    {

    }

    public override void OnSpawn(GameObject projectile)
    {
        base.OnSpawn(projectile);


    }
}