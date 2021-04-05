using System;
using System.Collections.Generic;
using UnityEngine;

// TODO: Client code. It gets a reference to this class and use the interface: Spawn and Despawn
// TODO: Make this a generic class

public class ObjectPoolingManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialSize = 10;

    // TODO: increase capacity of the pool

    private readonly Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        Init();
    }

    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        try
        {
            GameObject gameObject = pool.Dequeue(); // throws exception if it is empty
            gameObject.transform.SetPositionAndRotation(position, rotation);
            gameObject.SetActive(true);

            return gameObject;
        }
        catch (Exception e)
        {
            print($"The queue is empty: {e.Message}");
            return null; // TODO: Handle null object in the client or directly increase capacity
        }
    }

    public void Despawn(GameObject gameObject)
    {
        Enqueue(gameObject);
    }

    private void Init()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject gameObject = Instantiate(prefab);
            Enqueue(gameObject);
        }
    }

    private void Enqueue(GameObject gameObject)
    {
        gameObject.SetActive(false);
        pool.Enqueue(gameObject);
    }
}