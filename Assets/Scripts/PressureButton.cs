using UnityEngine;

public class PressureButton : MonoBehaviour
{
    public string playerTag;
    public GameObject objectToActivate;

    public Vector3 pressedScale = new Vector3(0.75f, 0.08f, 1f);
    private Vector3 originalScale;

    private bool isPressed = false;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPressed && collision.CompareTag(playerTag))
        {
            isPressed = true;
            objectToActivate.SetActive(true);
            transform.localScale = pressedScale;
        }
    }
}