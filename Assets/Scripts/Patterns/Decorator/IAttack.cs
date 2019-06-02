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


public abstract class AttackDecorator : IAttack
{
    private IAttack _attack;
    protected List<string> ignoreTags = new List<string>();

    public AttackDecorator(IAttack attack)
    {
        this._attack = attack;
    }

    public virtual void OnSpawn(GameObject projectile) {
        this._attack.OnSpawn(projectile);
    }
    public virtual void OnLand(GameObject projectile, Collider2D collisionData) {
        this._attack.OnLand(projectile, collisionData);
    }

}

public class FireAttack : AttackDecorator
{
    public Vector3 offset = new Vector2(0.25f, 0.25f);
    

    public FireAttack(IAttack attack) : base(attack)
    {
        ignoreTags = new List<string> { "Water" };
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

        if (ignoreTags.Contains(collisionData.gameObject.tag))
            return;

        if (collisionData.gameObject.tag == "Destroyable")
            GameObject.Destroy(collisionData.gameObject);

        GameObject.Instantiate(AssetManager.instance.ExplosionEffect, projectile.transform.position, Quaternion.identity);
        GameObject.Instantiate(AssetManager.instance.ExplosionEffect, projectile.transform.position + offset, Quaternion.identity);
        GameObject.Instantiate(AssetManager.instance.ExplosionEffect, projectile.transform.position - offset, Quaternion.identity);
        Debug.Log("LANDED : FIRE!!!!");
    }
}


public class IceAttack : AttackDecorator
{
    public Vector3 offset = new Vector2(0.25f, 0.25f);

    public IceAttack(IAttack attack) : base(attack)
    {
        ignoreTags = new List<string> { "Algo" };
    }

    public override void OnSpawn(GameObject projectile)
    {
        base.OnSpawn(projectile);

        projectile.GetComponentInChildren<SpriteRenderer>().sprite = AssetManager.instance.IceSprite;
        projectile.GetComponentInChildren<SpriteRenderer>().color = new Color(0, 255, 255);
        Debug.Log("SPAWNED : ICE!!!!");
    }

    public override void OnLand(GameObject projectile, Collider2D collisionData)
    {
        base.OnLand(projectile, collisionData);

        GameObject.Instantiate(AssetManager.instance.IceEffect, projectile.transform.position, Quaternion.identity);
        GameObject.Instantiate(AssetManager.instance.IceEffect, projectile.transform.position + offset, Quaternion.identity);
        GameObject.Instantiate(AssetManager.instance.IceEffect, projectile.transform.position - offset, Quaternion.identity);

        GameObject.Instantiate(AssetManager.instance.IceEffect2, projectile.transform.position, Quaternion.identity);
        Debug.Log("LANDED : ICE!!!!");

        if (collisionData.gameObject.tag == "Water")
        {
            Vector3 offset = new Vector3(0, 2f, 0f);

            collisionData.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.5f);
            collisionData.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            collisionData.gameObject.GetComponent<BuoyancyEffector2D>().useColliderMask = false;
        }
    }
}