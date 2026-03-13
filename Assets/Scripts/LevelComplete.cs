using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public Door bloomDoor;
    public Door dewDoor;
    public GameObject winScreen;
    public LevelMusic levelMusic;

    public int currentLevelNumber = 1;

    private bool levelFinished = false;

    void Update()
    {
        if (levelFinished) return;

        if (bloomDoor.isPlayerInside && dewDoor.isPlayerInside)
        {
            levelFinished = true;
            WinLevel();
        }
    }

    void WinLevel()
    {
        if (levelMusic != null)
        {
            levelMusic.StopMusic();
        }

        winScreen.SetActive(true);
        Time.timeScale = 0f;

        WinEffect effect = GetComponent<WinEffect>();
        if (effect != null)
        {
            effect.PlayWinEffect();
        }

        Debug.Log("Level Complete!");
    }

    public void ReturnToLevelMap()
    {
        if (levelMusic != null)
        {
            levelMusic.StopMusic();
        }

        int completedLevel = PlayerPrefs.GetInt("CompletedLevel", 0);
        if (currentLevelNumber > completedLevel)
        {
            PlayerPrefs.SetInt("CompletedLevel", currentLevelNumber);
        }

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (currentLevelNumber + 1 > unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevelNumber + 1);
        }

        PlayerPrefs.Save();

        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelMap");
    }
}