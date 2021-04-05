﻿using System;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField] protected HealthData healthData;

    [SerializeField] private GameObject damageEffectPrefab;
    [SerializeField] private GameObject explosionPrefab;

    protected int currentHealth;

    private ISelfDestroyable destroyable;

    private void Awake()
    {
        destroyable = GetComponent<ISelfDestroyable>();

        currentHealth = healthData.Health;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth = Math.Max(0, currentHealth - amount);

        Instantiate(damageEffectPrefab, transform.position, transform.rotation);

        if (currentHealth == 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        destroyable.Destroy();
    }
}