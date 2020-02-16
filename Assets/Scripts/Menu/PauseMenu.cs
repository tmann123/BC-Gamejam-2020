using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool gameIsPaused = false;

    // Resume game
    public void Resume() {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    // Pause game
    public void Pause() {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    // Go back to the main menu
    public void Quit() {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
