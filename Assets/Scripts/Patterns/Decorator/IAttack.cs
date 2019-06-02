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
        if (collisionData.gameObject.tag == "Destroyable")
            GameObject.Destroy(collisionData.gameObject);


        Debug.Log("Landed base attack!");
        GameObject.Destroy(projectile);
    }

}


public abstract class AttackDecorator : IAttack
{
    private IAttack _attack;

    public AttackDecorator(IAttack attack)
    {
        this._attack = attack;
    }

    public virtual void OnSpawn(GameObject projectile) { }
    public virtual void OnLand(GameObject projectile, Collider2D collisionData) { }

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

    public override void OnLand(GameObject projectile, Collider2D collisionData)
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

    public override void OnLand(GameObject projectile, Collider2D collisionData)
    {
        base.OnLand(projectile, collisionData);

        //GameObject.Instantiate(AssetManager.instance.FireSprite, projectile.transform.position, Quaternion.identity);
        Debug.Log("LANDED : ICE!!!!");
    }
}