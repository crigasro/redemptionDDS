using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public static AssetManager instance;



    public GameObject ProjectilePrefab;


    public GameObject ExplosionEffect;
    public GameObject IceEffect;
    public GameObject IceEffect2;


    public Sprite FireSprite;
    public Sprite IceSprite;



    private void Start()
    {
        MakeSingleton();
    }
    protected void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
