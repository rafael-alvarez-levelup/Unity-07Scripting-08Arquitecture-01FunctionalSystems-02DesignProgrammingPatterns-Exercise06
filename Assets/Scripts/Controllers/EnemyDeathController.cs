using UnityEngine;

public class EnemyDeathController : MonoBehaviour
{
    private IEnemyDeathEventHandler enemyDeathEventHandler;
    private IAddScorable addScorable;
    private IScorable scorable;

    private void Awake()
    {
        enemyDeathEventHandler = GetComponent<IEnemyDeathEventHandler>();
        addScorable = GetComponent<IAddScorable>();

        scorable = FindObjectOfType<ScoreManager>();
    }

    private void OnEnable()
    {
        enemyDeathEventHandler.OnEnemyDeath += EnemyDeathEventHandler_OnEnemyDeath;
    }

    private void OnDestroy()
    {
        enemyDeathEventHandler.OnEnemyDeath -= EnemyDeathEventHandler_OnEnemyDeath;
    }

    private void EnemyDeathEventHandler_OnEnemyDeath()
    {
        addScorable.AddScore(scorable);
    }
}