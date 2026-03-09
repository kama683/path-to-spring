using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    public string killerTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(killerTag))
        {
            // Сначала возвращаем время — на случай если было 0
            Time.timeScale = 1f;

            // Перезапускаем сцену
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}