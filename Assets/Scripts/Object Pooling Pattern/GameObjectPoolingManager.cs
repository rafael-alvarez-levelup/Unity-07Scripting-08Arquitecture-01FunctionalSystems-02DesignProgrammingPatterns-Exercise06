using System.Collections.Generic;
using UnityEngine;

// DONE

public class GameObjectPoolingManager : MonoBehaviour, IObjectPooling
{
    private readonly Queue<GameObject> pool = new Queue<GameObject>();

    [SerializeField] private GameObject prefab;

    public void InitializePool(List<GameObject> gameObjects)
    {
        prefab = gameObjects[0];

        for (int i = 0; i < gameObjects.Count; i++)
        {
            GameObject gameObject = Instantiate(gameObjects[i], transform);
            Enqueue(gameObject);
        }
    }

    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            GameObject gameObject = Instantiate(prefab, transform);
            Enqueue(gameObject);
        }

        return GetGameObject(position, rotation);
    }

    public void Despawn(GameObject gameObject)
    {
        Enqueue(gameObject);
    }

    private void Enqueue(GameObject gameObject)
    {
        gameObject.SetActive(false);
        pool.Enqueue(gameObject);
    }

    private GameObject GetGameObject(Vector3 position, Quaternion rotation)
    {
        GameObject gameObject = pool.Dequeue();
        gameObject.transform.SetPositionAndRotation(position, rotation);
        gameObject.SetActive(true);

        return gameObject;
    }
}