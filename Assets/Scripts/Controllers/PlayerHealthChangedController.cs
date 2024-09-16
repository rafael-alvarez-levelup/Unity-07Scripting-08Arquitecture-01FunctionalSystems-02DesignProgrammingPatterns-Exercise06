using UnityEngine;

public class PlayerHealthChangedController : MonoBehaviour
{
    private IPlayerHealthChangedEventHandler playerHealthChangedEventHandler;
    private IUpdateLifebar lifebarUpdater;

    private void Awake()
    {
        playerHealthChangedEventHandler = GetComponent<IPlayerHealthChangedEventHandler>();

        lifebarUpdater = FindObjectOfType<LifebarManager>();
    }

    private void OnEnable()
    {
        playerHealthChangedEventHandler.OnPlayerHealthChanged += PlayerHealthChangedEventHandler_OnPlayerHealthChanged;
    }

    private void OnDestroy()
    {
        playerHealthChangedEventHandler.OnPlayerHealthChanged -= PlayerHealthChangedEventHandler_OnPlayerHealthChanged;
    }

    private void PlayerHealthChangedEventHandler_OnPlayerHealthChanged(int currentHealth, int maxHealth)
    {
        lifebarUpdater.UpdateLifebar(currentHealth, maxHealth);
    }
}