using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Starts game in the main scene
    public void LoadGameScene() {
        SceneManager.LoadSceneAsync("TerrrainMaking OwO");
    }

    // Quit out of the program
    public void Quit() {
        Application.Quit();
    }
}
