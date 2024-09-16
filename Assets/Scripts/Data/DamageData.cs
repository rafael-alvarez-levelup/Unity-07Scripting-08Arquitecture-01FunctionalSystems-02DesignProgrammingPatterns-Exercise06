using UnityEngine;

[CreateAssetMenu(fileName = "NewDamage", menuName = "ScriptableObject/Damage")]
public class DamageData : ScriptableObject
{
    public int Damage => damage;

    [SerializeField] private int damage;
}