using TMPro;
using UnityEngine;

/// <summary>
/// Manages core game state, including time, pausing, and game over conditions.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject pauseMenuText;
    [SerializeField] float startTime = 40f;

    // Track the game's state.
    float timeLeft;
    bool gameOver = false;
    bool isPaused = false;

    // Check if the game is over.
    public bool GameOver => gameOver;


    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        DecreaseTime();
        HandlePauseInput();
    }

    // Checks input to toggle the pause state.
    void HandlePauseInput()
    {
        if (gameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();

            else
                PauseGame();
        }
    }

    // Pauses the game by freezing time and player controls.
    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        playerController.enabled = false;

        pauseMenuText.SetActive(true);
    }

    // Resumes the game by enabling player controls.
    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        playerController.enabled = true;

        pauseMenuText.SetActive(false);
    }

    // Exits the game application.
    public void QuitGame()
    {
        // Quits the application when running in a built game.
        Application.Quit();

        // Stop Unity Editor for testing.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Increases the game time
    public void IncreaseTime(float amount)
    {
        if (isPaused)
            return;

        timeLeft += amount;
    }

    // Decreases the time and updates the UI text.
    void DecreaseTime()
    {
        if (gameOver || isPaused)
            return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        // Checks if time has run out.
        if (timeLeft <= 0)
        {
            PlayerGameOver();
        }
    }


    // Sets the game to a game-over state.
    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);

        // Slows down time slightly for a dramatic effect.
        Time.timeScale = 0.1f;
    }
}
