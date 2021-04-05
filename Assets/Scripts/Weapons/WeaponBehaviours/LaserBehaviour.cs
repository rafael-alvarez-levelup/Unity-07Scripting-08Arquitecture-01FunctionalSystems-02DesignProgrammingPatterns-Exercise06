using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LaserBehaviour : MonoBehaviour, IAddVelocityChangeForce
{
    [SerializeField] private float force = 15f;

    private Rigidbody myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;
    }

    public void AddVelocityChangeForce(Vector3 direction)
    {
        myRigidbody.AddForce(direction * force, ForceMode.VelocityChange);
    }
}