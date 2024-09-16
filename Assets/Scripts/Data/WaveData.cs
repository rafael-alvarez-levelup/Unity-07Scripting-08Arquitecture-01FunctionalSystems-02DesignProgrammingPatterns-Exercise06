using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "ScriptableObject/Wave")]
public class WaveData : ScriptableObject
{
    public List<GameObject> Sequence => sequence;
    public float Delay => delay;

    [SerializeField] private List<GameObject> sequence = new List<GameObject>();
    [SerializeField] private float delay;
}