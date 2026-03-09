using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public Door bloomDoor;
    public Door dewDoor;

    // Ссылка на UI-объект экрана победы
    public GameObject winScreen;

    // Флаг чтобы победа не срабатывала каждый кадр
    private bool levelFinished = false;

    void Update()
    {
        // Если уже победили — больше не проверяем
        if (levelFinished) return;

        if (bloomDoor.isPlayerInside && dewDoor.isPlayerInside)
        {
            levelFinished = true;
            WinLevel();
        }
    }

    void WinLevel()
    {
        // Показываем экран победы
        winScreen.SetActive(true);

        // Останавливаем время — персонажи замирают
        Time.timeScale = 0f;

        GetComponent<WinEffect>().PlayWinEffect();

        Debug.Log("Level Complete!");
    }

    // Эта функция будет вызываться кнопкой Next Level
    public void NextLevel()
    {
        // Возвращаем время
        Time.timeScale = 1f;

        // Загружаем следующую сцену
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        // Если следующей сцены нет — возвращаемся в меню (сцена 0)
        if (nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}