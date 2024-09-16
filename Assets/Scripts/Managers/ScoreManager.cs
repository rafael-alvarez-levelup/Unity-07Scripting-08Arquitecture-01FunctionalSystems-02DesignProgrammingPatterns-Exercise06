using UnityEngine;

public class ScoreManager : MonoBehaviour, IScorable
{
    private IUpdateScore scoreUpdater;
    private int score;

    private void Awake()
    {
        scoreUpdater = GetComponent<IUpdateScore>();
    }

    private void Start()
    {
        scoreUpdater.UpdateScore(score);
    }

    public void AddScore(int amount)
    {
        score += amount;

        scoreUpdater.UpdateScore(score);
    }
}