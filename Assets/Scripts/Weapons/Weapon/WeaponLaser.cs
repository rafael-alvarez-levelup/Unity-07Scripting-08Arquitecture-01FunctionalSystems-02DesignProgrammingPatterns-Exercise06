using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// DONE

public class WeaponLaser : WeaponBase
{
    [SerializeField] private int numberOfShots = 3;

    private IObjectPooling laserPoolingManager;

    private void Awake()
    {
        laserPoolingManager = FindObjectOfType<LaserPoolingManager>();

        InitializeLaserPool();
    }

    public override void Fire(Transform firePoint)
    {
        GameObject laser = laserPoolingManager.Spawn(firePoint.position, firePoint.rotation, prefab);

        IAddVelocityChangeForce launcher = laser.GetComponent<IAddVelocityChangeForce>();

        Assert.IsNotNull(launcher, $"{laser.gameObject.name} doesn't have launcher behaviour component");

        launcher.AddVelocityChangeForce(transform.up);
    }

    private void InitializeLaserPool()
    {
        List<GameObject> prefabs = new List<GameObject>();

        for (int i = 0; i < numberOfShots; i++)
        {
            prefabs.Add(prefab);
        }

        laserPoolingManager.InitializePool(prefabs);
    }
}