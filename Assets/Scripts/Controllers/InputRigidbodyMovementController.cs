using UnityEngine;

public class InputRigidbodyMovementController : MonoBehaviour
{
    private IMovable movable;
    private EngineBehaviour engineBehaviour;
    private float horizontalMovement;

    private void Awake()
    {
        movable = GetComponent<RigidbodyMovementBehaviour>();
        engineBehaviour = GetComponent<EngineBehaviour>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        engineBehaviour.Toggle(horizontalMovement != 0);
    }

    private void FixedUpdate()
    {
        // Already handles a null velocity.
        movable.Move(transform.right * horizontalMovement);
    }
}