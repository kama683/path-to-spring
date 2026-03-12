using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform bloom;
    public Transform thaw;

    public float smoothSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 10f;
    public float zoomPadding = 3f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (bloom == null || thaw == null) return;

        // Находим середину между двумя персонажами
        Vector3 midPoint = (bloom.position + thaw.position) / 2f;
        midPoint.z = transform.position.z; // Z камеры не меняем

        // Плавно двигаем камеру к середине
        Vector3 smoothPos = Vector3.Lerp(transform.position, midPoint, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;

        // Зум — чем дальше друг от друга, тем шире камера
        float distance = Vector3.Distance(bloom.position, thaw.position);
        float targetZoom = Mathf.Clamp(distance + zoomPadding, minZoom, maxZoom);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, smoothSpeed * Time.deltaTime);
    }
}