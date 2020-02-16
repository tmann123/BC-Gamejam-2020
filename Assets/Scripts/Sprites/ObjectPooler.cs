using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> objectDictionary;

    [System.Serializable]
    public class Pool{
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;
    void Start()
    {
        objectDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools){
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++){

                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);

            }

            objectDictionary.Add(pool.tag, objectPool);
        }

        
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation){
        if (!objectDictionary.ContainsKey(tag)){
            Debug.Log("you fked");
            return null;
        }

        GameObject objectToSpawn = objectDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObj != null){
            pooledObj.OnObjectSpawn();
        }

        objectDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
