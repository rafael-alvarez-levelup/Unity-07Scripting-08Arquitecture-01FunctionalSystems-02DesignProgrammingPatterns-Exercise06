using UnityEngine;

// DONE

// TODO: Better way to inject poolingManager

public class DestroySelfBehaviour : MonoBehaviour, ISelfDestroyable, ISetPoolingManager
{
    // TODO: Doesn't work with private accessor
    public GameObjectPoolingManager poolingManager;

    // TODO: Doesn't work with interfaces
    public void SetPoolingManager(GameObjectPoolingManager gameObjectPoolingManager)
    {
        poolingManager = gameObjectPoolingManager;
    }

    public virtual void Destroy()
    {
        if (poolingManager != null)
        {
            poolingManager.Despawn(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}