using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : AttackDecorator
{
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

        DoEffect(AssetManager.instance.ExplosionEffect, projectile);
        Debug.Log("LANDED : FIRE!!!!");
    }
}


public class IceAttack : AttackDecorator
{
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

        DoEffect(AssetManager.instance.IceEffect, projectile);

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