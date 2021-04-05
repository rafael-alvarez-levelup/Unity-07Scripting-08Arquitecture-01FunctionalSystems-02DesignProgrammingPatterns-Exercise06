using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovementBehaviour : MonoBehaviour, IMovable
{
    [SerializeField] private SpeedData speedData;

    private Rigidbody myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Assert.IsTrue(Time.inFixedTimeStep);

        // Must handle a null velocity.
        myRigidbody.velocity = direction * speedData.Speed;
    }
}