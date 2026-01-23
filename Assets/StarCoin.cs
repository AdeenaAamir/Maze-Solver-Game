using UnityEngine;

public class StarCoin : MonoBehaviour
{
    public float rotateSpeed = 60f; // for rotation animation

    private Vector3 startPosition;

    void Start()
    {
        // Save original position (optional if you want reset behavior)
        startPosition = transform.position;
    }

    void Update()
    {
        // Make the star rotate for visual effect
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object hitting the star is the player
        if (other.GetComponent<PlayerMovement>() != null)
        {
            // "Collect" the star
            gameObject.SetActive(false); // makes it disappear

            // Optional: add score here
            // ScoreManager.instance.AddScore(1);
        }
    }

    // Optional: reset the star (call this when restarting the game)
    public void ResetStar()
    {
        gameObject.SetActive(true); // make it visible again
        transform.position = startPosition; // reset position if moved
    }
}