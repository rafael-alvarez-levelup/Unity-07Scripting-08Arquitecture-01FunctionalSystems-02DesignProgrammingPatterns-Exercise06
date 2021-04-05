using UnityEngine;
using UnityEngine.Assertions;

public class WeaponLaser : WeaponBase
{
    public override void Fire(Transform firePoint)
    {
        GameObject laser = Instantiate(prefab, firePoint.position, firePoint.rotation);

        IAddVelocityChangeForce launcher = laser.GetComponent<IAddVelocityChangeForce>();

        Assert.IsNotNull(launcher, $"{laser.gameObject.name} doesn't have launcher behaviour component");

        launcher.AddVelocityChangeForce(transform.up);
    }
}