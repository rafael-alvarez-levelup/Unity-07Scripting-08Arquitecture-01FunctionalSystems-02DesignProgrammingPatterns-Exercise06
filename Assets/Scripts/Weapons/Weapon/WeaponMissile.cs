using UnityEngine;
using UnityEngine.Assertions;

public class WeaponMissile : WeaponBase
{
    public override void Fire(Transform firePoint)
    {
        GameObject missile = Instantiate(prefab, firePoint.position, firePoint.rotation);

        ISearchAndDestroy controller = missile.GetComponent<ISearchAndDestroy>();

        Assert.IsNotNull(controller, $"{missile.gameObject.name} doesn't have controller component");

        controller.SearchAndDestroy();
    }
}