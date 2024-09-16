public delegate void PlayerDeathEventHandler();

public interface IPlayerDeathEventHandler
{

    event PlayerDeathEventHandler OnPlayerDeath;
}