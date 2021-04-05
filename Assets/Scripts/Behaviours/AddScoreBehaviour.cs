using UnityEngine;

public class AddScoreBehaviour : MonoBehaviour, IAddScorable
{
    [SerializeField] private int score;

    public void AddScore(IScorable scorable)
    {
        scorable.AddScore(score);
    }
}