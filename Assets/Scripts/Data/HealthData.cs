using UnityEngine;

[CreateAssetMenu(fileName = "NewHealth", menuName = "ScriptableObject/Health")]
public class HealthData : ScriptableObject
{
    public int Health => health;

    [SerializeField] private int health;
}