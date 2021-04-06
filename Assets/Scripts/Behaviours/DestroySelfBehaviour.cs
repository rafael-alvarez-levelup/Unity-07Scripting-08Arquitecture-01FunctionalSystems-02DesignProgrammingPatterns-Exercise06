using UnityEngine;
using UnityEngine.Assertions;

// DONE

public class DestroySelfBehaviour : MonoBehaviour, ISelfDestroyable, ISetGameObjectPoolingManager
{
    // WHAT? It doesn't work without SerializeField
    [SerializeField] private GameObjectPoolingManager gameObjectPoolingManager;

    public void SetGameObjectPoolingManager(GameObjectPoolingManager gameObjectPoolingManager)
    {
        this.gameObjectPoolingManager = gameObjectPoolingManager;
    }

    public virtual void Destroy()
    {
        Assert.IsNotNull(gameObjectPoolingManager);

        if (gameObjectPoolingManager != null)
        {
            gameObjectPoolingManager.Despawn(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}