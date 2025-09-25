using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [System.Serializable]
    public class  ObjectPool
    {
        public string poolName;
        public GameObject prefab;
        public int poolsize;
    }

    public List<ObjectPool> pools;                                // List to store different object pools we are creating
    Dictionary<string, Queue<GameObject>> poolDictionary;            // Dictionary to hold the object pools we are creating 

    //It is called before the first frame 
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();       // Initialize the dictionary we are using to hold the object pools


        // loop through each pool we created and create a queue for each pool
        foreach (ObjectPool pool in pools)
        {
            // Create a queue for each pool
            Queue<GameObject> objectPool = new Queue<GameObject>();
            // Instantiate the objects and add them to the queue
            for (int i = 0; i < pool.poolsize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);        // Instantiate the object
                obj.SetActive(false);                               // Deactivate the object
                objectPool.Enqueue(obj);                            // Add the object to the queue
            }
            poolDictionary.Add(pool.poolName, objectPool);             // Add the queue to the dictionary
        }
    }

    // public Method to spawn an object from the pool
    public GameObject SpawnFromPool(string poolName, Vector3 position, Quaternion rotation)
    {
        // Check if the pool exists 
        GameObject objectToSpawn = poolDictionary[poolName].Dequeue();      // Get the object from the pool
        objectToSpawn.SetActive(true);                                       // Activate the object
        objectToSpawn.transform.position = position;                         // Set the position of the object
        objectToSpawn.transform.rotation = rotation;                         // Set the rotation of the object

        poolDictionary[poolName].Enqueue(objectToSpawn);                 // Add the object back to the pool
        return objectToSpawn;                                               // Return the object
    }
}
