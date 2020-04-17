using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGameObjectPooled : MonoBehaviour
{ 
    [SerializeField]
    GameObjectPool gameObjectPool;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        var shot = gameObjectPool.Get(); //falta get, conseguir la bala
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
}
