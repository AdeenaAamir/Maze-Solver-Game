using UnityEngine;
using TMPro;  // Use this for TextMeshPro

public class GameManager : MonoBehaviour
{
    private TMP_Text timerText;  // Automatically assigned
    public float timeRemaining = 60f; // Set your timer in seconds
    private bool timerIsRunning = false;

    void Awake()
    {
        // Find the Timer Text in the scene automatically
        GameObject textObj = GameObject.Find("TimerText"); // Make sure your UI Text object is named "TimerText"
        if (textObj != null)
        {
            timerText = textObj.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.LogError("TimerText object not found in the scene!");
        }
    }

    void Start()
    {
        timerIsRunning = true;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                TimerEnded();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            // Format time as MM:SS
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void TimerEnded()
    {
        Debug.Log("Time's up!");
        // Add any logic for when timer ends
    }
}
