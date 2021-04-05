using UnityEngine;

[CreateAssetMenu(fileName = "NewHealing", menuName = "ScriptableObject/Healing")]
public class HealingData : ScriptableObject
{
    public int Healing => healing;

    [SerializeField] private int healing;
}