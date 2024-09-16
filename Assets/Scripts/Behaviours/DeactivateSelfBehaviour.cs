using UnityEngine;

// DONE

public class DeactivateSelfBehaviour : MonoBehaviour, ISelfKill, ISetPoolingManager
{
    private IObjectPooling poolingManager;

    public void SetPoolingManager(IObjectPooling poolingManager)
    {
        this.poolingManager = poolingManager;
    }

    public void Kill()
    {
        poolingManager.Despawn(gameObject);
    }
}