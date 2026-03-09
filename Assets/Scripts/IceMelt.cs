using UnityEngine;

public class IceMelt : MonoBehaviour
{
    // Этот скрипт вешается на ледяной блок.
    // Когда Thaw касается льда — лёд тает (деактивируется).

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем: тот кто вошёл — это Thaw?
        if (collision.CompareTag("Thaw"))
        {
            // Деактивируем ледяной блок — он "тает"
            gameObject.SetActive(false);
        }
    }
}