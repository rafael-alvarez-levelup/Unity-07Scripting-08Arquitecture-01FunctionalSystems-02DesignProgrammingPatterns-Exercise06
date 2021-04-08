using UnityEngine;

// DONE

public class DestroySelfBehaviour : MonoBehaviour, ISelfDestroyable, ISetPoolingManager
{
    private IObjectPooling poolingManager;

    public void SetPoolingManager(IObjectPooling gameObjectPoolingManager)
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