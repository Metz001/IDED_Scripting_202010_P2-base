using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotGameObject : MonoBehaviour, IGameObjectPooled
{
    public float moveSpeed = 20f;

    private float lifeTime;
    private float maxLifeTime = 5f;

    private GameObjectPool pool;
    public GameObjectPool Pool
    {
        get { return pool; }
        set
        {
            if (pool == null)
                pool = value;
            else
                throw new System.Exception("Se jodió el pool Shot");
        }
    }

    private void OnEnable()
    {
        lifeTime = 0f;
    }


    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            pool.Reload(this.gameObject);
        }
        
    }
       
}

internal interface IGameObjectPooled
{
    GameObjectPool Pool { get; set; }
}

 