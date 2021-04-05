using UnityEngine;

public class HealBehaviour : MonoBehaviour, IDoHealable
{
    [SerializeField] private HealingData healData;

    public void DoHeal(IHealable target)
    {
        target.Heal(healData.Healing);
    }
}