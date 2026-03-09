using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public Door bloomDoor;
    public Door dewDoor;

    void Update()
    {
        if (bloomDoor.isPlayerInside && dewDoor.isPlayerInside)
        {
            Debug.Log("Level Complete!");
        }
    }
}