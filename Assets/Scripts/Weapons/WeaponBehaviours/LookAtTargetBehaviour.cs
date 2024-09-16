using UnityEngine;

public class LookAtTargetBehaviour : MonoBehaviour, ILookAtTarget
{
    [SerializeField] private float rotationSpeed = 10f;

    private Transform target;

    private void Update()
    {
        if (target == null) return;

        Vector3 vectorToTarget = target.position - transform.position;
        float angleToRotate = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.AngleAxis(angleToRotate, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}