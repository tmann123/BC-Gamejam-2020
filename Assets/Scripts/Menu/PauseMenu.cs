using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool gameIsPaused = false;
    private GameObject playerRef;

    // Resume game
    public void Resume() {
        Time.timeScale = 1f;
        gameIsPaused = false;

        // Re-enable player inputs on game resume
        playerRef.GetComponent<PlayerInputs>().enabled = true;

        // Disable the pause menu while game is running
        transform.gameObject.SetActive(false);

        // Lock cursor so player can use it to move camera
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Pause game
    public void Pause(GameObject reference) {
        Time.timeScale = 0f;
        playerRef = reference;
        gameIsPaused = true;

        // Disable player inputs while game is paused
        playerRef.GetComponent<PlayerInputs>().enabled = false;

        // Unlock cursor so player can select buttons
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Go back to the main menu
    public void Quit() {
        // TimeScale propegates through load so it needs to be set to 1
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
