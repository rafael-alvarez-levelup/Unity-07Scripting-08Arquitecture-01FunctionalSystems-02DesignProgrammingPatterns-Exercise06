using UnityEngine;

[CreateAssetMenu(fileName = "NewSpeed", menuName = "ScriptableObject/Speed")]
public class SpeedData : ScriptableObject
{
    public float Speed => speed;

    [SerializeField] private float speed;
}