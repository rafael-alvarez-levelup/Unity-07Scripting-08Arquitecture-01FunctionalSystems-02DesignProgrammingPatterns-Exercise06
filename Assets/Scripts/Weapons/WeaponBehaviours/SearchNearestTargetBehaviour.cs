using UnityEngine;

public class SearchNearestTargetBehaviour : MonoBehaviour, ISearchNearestTarget
{
    [SerializeField] private float radius;
    [SerializeField] LayerMask layer;

    public Transform SearchNearestTarget()
    {
        Transform target = null;

        float minDistance = float.MaxValue;

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layer);

        foreach (Collider collider in colliders)
        {
            float distance = Vector3.SqrMagnitude(transform.position - collider.transform.position);

            if (distance < minDistance)
            {
                target = collider.transform;

                minDistance = distance;
            }
        }

        return target;
    }
}