using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public MazeTimer mazeTimer;

    void Start()
    {
        // Automatically find the MazeTimer if it wasn't assigned in the Inspector
        if (mazeTimer == null)
        {
            mazeTimer = Object.FindFirstObjectByType<MazeTimer>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the timer was found and if the object is the Player
        if (other.CompareTag("Player") && mazeTimer != null)
        {
            mazeTimer.EndGame(true);
        }
        else if (mazeTimer == null)
        {
            Debug.LogError("FinishPoint: No MazeTimer found in the scene!");
        }
    }
}