using UnityEngine;

public class MoveToTargetBehaviour : MonoBehaviour, IMoveToTarget
{
    [SerializeField] private float speed = 6f;

    private Transform target;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}