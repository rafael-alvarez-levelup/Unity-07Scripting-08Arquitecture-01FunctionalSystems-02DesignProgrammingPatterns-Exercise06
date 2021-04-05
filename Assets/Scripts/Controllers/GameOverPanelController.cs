using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelController : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button exitButton;

    private IPlayerDeathEventHandler playerDeathEventHandler;

    private void Awake()
    {
        playerDeathEventHandler = FindObjectOfType<PlayerHealthBehaviour>();

        playAgainButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        exitButton.onClick.AddListener(() => Application.Quit());
    }

    private void Start()
    {
        Hide();
    }

    private void OnEnable()
    {
        playerDeathEventHandler.OnPlayerDeath += PlayerDeathEventHandler_OnPlayerDeath;
    }

    private void OnDestroy()
    {
        playerDeathEventHandler.OnPlayerDeath -= PlayerDeathEventHandler_OnPlayerDeath;
    }

    private void PlayerDeathEventHandler_OnPlayerDeath()
    {
        Show();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}