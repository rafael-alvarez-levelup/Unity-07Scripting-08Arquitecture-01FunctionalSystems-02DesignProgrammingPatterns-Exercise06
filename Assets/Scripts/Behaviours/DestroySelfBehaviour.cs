using UnityEngine;

public class DestroySelfBehaviour : MonoBehaviour, ISelfKill
{
    public void Kill()
    {
        Destroy(gameObject);
    }
}