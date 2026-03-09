using UnityEngine;

public class WinEffect : MonoBehaviour
{
    // Ссылка на систему частиц
    public ParticleSystem flowerBurst;

    // Эту функцию вызовем при победе
    public void PlayWinEffect()
    {
        if (flowerBurst != null)
        {
            flowerBurst.Play();
        }
    }
}