using UnityEngine;

public class DealDamageBehaviour : MonoBehaviour, IDealDamageable
{
    [SerializeField] private DamageData damageData;

    public void DealDamage(IDamageable target)
    {
        target.TakeDamage(damageData.Damage);
    }
}