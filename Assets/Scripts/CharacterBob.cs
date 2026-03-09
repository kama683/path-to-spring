using UnityEngine;

public class CharacterBob : MonoBehaviour
{
    [Header("Настройки покачивания")]
    public float bobHeight = 0.05f;  // высота покачивания
    public float bobSpeed = 3f;       // скорость покачивания

    private Vector3 startPosition;

    void Start()
    {
        // Запоминаем начальную позицию
        startPosition = transform.localPosition;
    }

    void Update()
    {
        // Синусоида создаёт плавное покачивание вверх-вниз
        float newY = startPosition.y + 
                     Mathf.Sin(Time.time * bobSpeed) * bobHeight;

        transform.localPosition = new Vector3(
            startPosition.x,
            newY,
            startPosition.z
        );
    }
}