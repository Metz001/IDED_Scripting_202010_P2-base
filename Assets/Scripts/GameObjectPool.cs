using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefabToPool;

    private Queue<GameObject> objects = new Queue<GameObject>();

    public static GameObjectPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;            //singleton
    }
    public GameObject Get()          //comienzo de Pool
    {
        if (objects.Count == 0)
            Addobjects(1);
        
        return objects.Dequeue();
    }

    private void Addobjects(int count)
    {
        var newObject = GameObject.Instantiate(prefabToPool);
        newObject.SetActive(false);
        objects.Enqueue(newObject);

        newObject.GetComponent<IGameObjectPooled>().Pool = this;
        
    }
    
    public void Reload(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
    


    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
