using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderMainMenu : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadLevelMap()
    {
        SceneManager.LoadScene("LevelMap");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}