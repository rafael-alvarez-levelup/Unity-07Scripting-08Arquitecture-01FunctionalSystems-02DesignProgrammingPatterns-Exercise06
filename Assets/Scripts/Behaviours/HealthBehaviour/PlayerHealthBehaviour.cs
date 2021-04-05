using System;
using UnityEngine;

public class PlayerHealthBehaviour : HealthBehaviour, IHealable, IPlayerHealthChangedEventHandler, IPlayerDeathEventHandler
{
    public event PlayerHealthChangedEventHandler OnPlayerHealthChanged;
    public event PlayerDeathEventHandler OnPlayerDeath;

    [SerializeField] private GameObject healEffectPrefab;

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);

        PlayerHealthChanged();
    }

    protected override void Die()
    {
        base.Die();

        PlayerDeath();
    }

    public void Heal(int amount)
    {
        if (currentHealth < healthData.Health)
        {
            currentHealth = Math.Min(currentHealth + amount, healthData.Health);

            Instantiate(healEffectPrefab, transform.position, transform.rotation);

            PlayerHealthChanged();
        }
    }

    private void PlayerDeath()
    {
        if (OnPlayerDeath != null)
        {
            OnPlayerDeath.Invoke();
        }
    }

    private void PlayerHealthChanged()
    {
        if (OnPlayerHealthChanged != null)
        {
            OnPlayerHealthChanged.Invoke(currentHealth, healthData.Health);
        }
    }
}