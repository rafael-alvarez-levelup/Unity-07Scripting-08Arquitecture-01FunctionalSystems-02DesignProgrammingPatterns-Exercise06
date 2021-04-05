using UnityEngine;
using UnityEngine.Assertions;

public class WeaponShell : WeaponBase
{
    [SerializeField] private int amount = 3;
    [SerializeField] private float angle = 90f;

    public override void Fire(Transform firePoint)
    {
        float fraction = angle / amount;

        for (int i = 0; i < amount; i++)
        {
            float degrees = fraction * i - (angle / 2) + (fraction / 2);
            float radians = Mathf.Deg2Rad * degrees;

            Vector3 direction = firePoint.rotation * new Vector2(Mathf.Sin(radians), Mathf.Cos(radians));

            GameObject shell = Instantiate(prefab, firePoint.position, Quaternion.Euler(direction));

            IAddVelocityChangeForce launcher = shell.GetComponent<IAddVelocityChangeForce>();

            Assert.IsNotNull(launcher, $"{shell.gameObject.name} doesn't have launcher behaviour component");

            launcher.AddVelocityChangeForce(direction.normalized);
        }
    }
}