using UnityEngine;

public class ContinuousRigidbodyMovementController : MonoBehaviour
{
    private IMovable rigidbodyMovementBehaviour;

    private void Awake()
    {
        rigidbodyMovementBehaviour = GetComponent<RigidbodyMovementBehaviour>();
    }

    private void FixedUpdate()
    {
        rigidbodyMovementBehaviour.Move(transform.up * -1);
    }
}