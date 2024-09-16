public delegate void EnemyDeathEventHandler();

public interface IEnemyDeathEventHandler
{
    event EnemyDeathEventHandler OnEnemyDeath;
}