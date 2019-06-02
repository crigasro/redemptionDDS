using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void OnSpawn(GameObject projectile);
    void OnLand(GameObject projectile, Collision2D collisionData);
}

public abstract class AttackDecorator : IAttack
{
    private IAttack _attack;

    public AttackDecorator(IAttack attack)
    {
        this._attack = attack;
    }

    public virtual void OnSpawn(GameObject projectile) { }
    public virtual void OnLand(GameObject projectile, Collision2D collisionData) {

        GameObject.Destroy(projectile);
    }

}

public class FireAttack : AttackDecorator
{
    public FireAttack(IAttack attack) : base(attack)
    {

    }

    public override void OnSpawn(GameObject projectile)
    {
        base.OnSpawn(projectile);

        projectile.GetComponentInChildren<SpriteRenderer>().sprite = AssetManager.instance.FireSprite;
        Debug.Log("SPAWNED : FIRE!!!!");
    }

    public override void OnLand(GameObject projectile, Collision2D collisionData)
    {
        base.OnLand(projectile, collisionData);

        GameObject.Instantiate(AssetManager.instance.FireSprite, projectile.transform.position, Quaternion.identity);
        Debug.Log("LANDED : FIRE!!!!");
    }
}


public class IceAttack : AttackDecorator
{
    public IceAttack(IAttack attack) : base(attack)
    {

    }

    public override void OnSpawn(GameObject projectile)
    {
        base.OnSpawn(projectile);

        //projectile.GetComponentInChildren<SpriteRenderer>().sprite = AssetManager.instance.FireSprite;
        Debug.Log("SPAWNED : ICE!!!!");
    }

    public override void OnLand(GameObject projectile, Collision2D collisionData)
    {
        base.OnLand(projectile, collisionData);

        //GameObject.Instantiate(AssetManager.instance.FireSprite, projectile.transform.position, Quaternion.identity);
        Debug.Log("LANDED : ICE!!!!");
    }
}