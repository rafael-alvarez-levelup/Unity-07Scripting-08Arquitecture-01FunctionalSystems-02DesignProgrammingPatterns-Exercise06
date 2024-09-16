using UnityEngine;
using UnityEngine.Assertions;

public class HealOnTriggerEnterLayerController : OnTriggerEnterLayerControllerBase
{
    private IDoHealable doHealable;

    private void Awake()
    {
        doHealable = GetComponent<IDoHealable>();
    }

    protected override void React(Collider other)
    {
        IHealable target = other.GetComponent<IHealable>();

        Assert.IsNotNull(target, $"{other.gameObject.name} doesn't implement IHealable interface");

        doHealable.DoHeal(target);
    }
}