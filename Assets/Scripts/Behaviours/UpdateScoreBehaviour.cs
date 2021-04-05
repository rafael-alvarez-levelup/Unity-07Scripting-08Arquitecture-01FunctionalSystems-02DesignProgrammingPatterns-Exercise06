using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreBehaviour : MonoBehaviour, IUpdateScore
{
    private Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString("0000");
    }
}