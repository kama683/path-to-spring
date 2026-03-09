using UnityEngine;

public class Door : MonoBehaviour
{
    public string playerTag;
    public bool isPlayerInside = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            isPlayerInside = false;
        }
    }
}