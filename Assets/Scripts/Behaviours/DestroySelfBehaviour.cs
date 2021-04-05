using UnityEngine;

public class DestroySelfBehaviour : MonoBehaviour, ISelfDestroyable
{
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}