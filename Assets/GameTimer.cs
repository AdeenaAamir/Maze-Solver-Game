using UnityEngine;
using UnityEngine.UI; // Required for legacy Text
using TMPro;           // Required for TextMeshPro

public class MazeTimer : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text timerText; // Change to 'public Text' if using Legacy UI Text
    public GameObject successText;
    public GameObject failText;

    [Header("Settings")]
    public float timeLeft = 60f;

    private bool timerStarted = false;
    private bool gameEnded = false;

    void Start()
    {
        // Ensure the game is running (in case it was paused before)
        Time.timeScale = 1f;

        // Hide messages at start with null checks
        if (successText != null) successText.SetActive(false);
        if (failText != null) failText.SetActive(false);

        UpdateTimerUI();
    }

    void Update()
    {
        if (gameEnded) return;

        // Start timer when player moves
        if (!timerStarted && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            timerStarted = true;
        }

        if (timerStarted)
        {
            timeLeft -= Time.deltaTime; //

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                EndGame(false); // Trigger Failure
            }

            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString(); //
        }
    }

    public void EndGame(bool success)
    {
        if (gameEnded) return; // Prevent multiple triggers

        gameEnded = true;
        Time.timeScale = 0f; // Pause the game

        if (success)
        {
            if (successText != null) successText.SetActive(true); //
        }
        else
        {
            if (failText != null) failText.SetActive(true); //
        }
    }
}