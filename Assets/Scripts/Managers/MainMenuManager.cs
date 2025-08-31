using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles main menu functions.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "GameScene";

    // New Game Button function
    public void StartNewGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    // Quit Game button function
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
