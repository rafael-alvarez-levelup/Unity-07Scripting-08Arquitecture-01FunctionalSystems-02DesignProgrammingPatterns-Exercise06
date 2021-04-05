public delegate void PlayerHealthChangedEventHandler(int currentHealth, int maxHealth);

public interface IPlayerHealthChangedEventHandler
{
    event PlayerHealthChangedEventHandler OnPlayerHealthChanged;
}