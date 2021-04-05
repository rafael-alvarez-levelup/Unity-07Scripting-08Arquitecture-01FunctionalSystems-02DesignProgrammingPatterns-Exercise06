using UnityEngine;

public class EnemyHealthBehaviour : HealthBehaviour, IEnemyDeathEventHandler
{
    public event EnemyDeathEventHandler OnEnemyDeath;

    [SerializeField] private float damageMultiplier;

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(Mathf.RoundToInt(amount * damageMultiplier));
    }

    protected override void Die()
    {
        base.Die();

        EnemyDeath();
    }

    private void EnemyDeath()
    {
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath.Invoke();
        }
    }
}