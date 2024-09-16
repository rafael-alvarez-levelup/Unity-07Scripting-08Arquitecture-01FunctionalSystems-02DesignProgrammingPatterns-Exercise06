using System.Collections.Generic;
using UnityEngine;

// DONE

public interface IObjectPooling
{
    void InitializePool(List<GameObject> gameObjects);
    GameObject Spawn(Vector3 position, Quaternion rotation, GameObject prefab = null);
    void Despawn(GameObject gameObject);
}