using System;
using System.Collections.Generic;
using UnityEngine;

// DONE

public class GameObjectPoolingManager : MonoBehaviour, IObjectPooling
{
    protected readonly Queue<GameObject> pool = new Queue<GameObject>();

    public void InitializePool(List<GameObject> prefabs)
    {
        for (int i = 0; i < prefabs.Count; i++)
        {
            GameObject prefab = Instantiate(prefabs[i], transform);
            Enqueue(prefab);
        }
    }

    public GameObject Spawn(Vector3 position, Quaternion rotation, GameObject prefab = null)
    {
        if (pool.Count == 0)
        {
            if (prefab == null) throw new Exception("The pool is empty! Pass prefab from client.");

            GameObject newPrefab = Instantiate(prefab, transform);
            Enqueue(newPrefab);
        }

        GameObject poolPrefab = pool.Dequeue();
        poolPrefab.transform.SetPositionAndRotation(position, rotation);
        poolPrefab.SetActive(true);

        return poolPrefab;
    }

    public void Despawn(GameObject prefab)
    {
        Enqueue(prefab);
    }

    protected void Enqueue(GameObject prefab)
    {
        prefab.SetActive(false);
        pool.Enqueue(prefab);
    }
}