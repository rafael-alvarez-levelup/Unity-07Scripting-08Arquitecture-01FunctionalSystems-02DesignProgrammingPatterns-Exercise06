using UnityEngine;
using UnityEngine.Assertions;

public class DealDamageOnTriggerEnterLayerController : OnTriggerEnterLayerControllerBase
{
    private IDealDamageable dealDamageable;

    private void Awake()
    {
        dealDamageable = GetComponent<IDealDamageable>();
    }

    protected override void React(Collider other)
    {
        IDamageable target = other.GetComponent<IDamageable>();

        Assert.IsNotNull(target, $"{other.gameObject.name} doesn't implement IDamageable interface");

        dealDamageable.DealDamage(target);
    }
}