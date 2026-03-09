using UnityEngine;

public class ButtonPulse : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.1f;

    private Vector3 originalScale;
    private SpriteRenderer sr;

    void Start()
    {
        originalScale = transform.localScale;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Пульсирующий размер
        float pulse = 1f + Mathf.Sin(Time.time * pulseSpeed) 
                          * pulseAmount;
        transform.localScale = originalScale * pulse;
    }
}