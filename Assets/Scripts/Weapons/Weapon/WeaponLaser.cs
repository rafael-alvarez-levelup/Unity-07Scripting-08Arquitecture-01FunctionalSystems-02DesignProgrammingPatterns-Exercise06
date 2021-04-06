using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// DONE

public class WeaponLaser : WeaponBase
{
    private GameObjectPoolingManager laserPoolingManager;

    private void Awake()
    {
        InitializeLaserPool();
    }

    public override void Fire(Transform firePoint)
    {
        GameObject laser = laserPoolingManager.Spawn(firePoint.position, firePoint.rotation);

        IAddVelocityChangeForce launcher = laser.GetComponent<IAddVelocityChangeForce>();

        Assert.IsNotNull(launcher, $"{laser.gameObject.name} doesn't have launcher behaviour component");

        launcher.AddVelocityChangeForce(transform.up);
    }

    private void InitializeLaserPool()
    {
        GameObject poolHolder = new GameObject("LaserPoolingManager", typeof(GameObjectPoolingManager));

        laserPoolingManager = poolHolder.GetComponent<GameObjectPoolingManager>();
        Assert.IsNotNull(laserPoolingManager);

        List<GameObject> prefabs = new List<GameObject>();

        for (int i = 0; i < 3; i++)
        {
            ISetGameObjectPoolingManager gameObjectPoolingManagerSetter = prefab.GetComponent<ISetGameObjectPoolingManager>();
            Assert.IsNotNull(gameObjectPoolingManagerSetter);

            // This doesn't work with interfaces
            gameObjectPoolingManagerSetter.SetGameObjectPoolingManager(laserPoolingManager);

            prefabs.Add(prefab);
        }

        laserPoolingManager.InitializePool(prefabs);
    }
}