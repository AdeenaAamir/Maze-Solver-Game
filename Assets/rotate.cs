using UnityEngine;

public class TrophyAnimation : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float floatHeight = 0.2f;
    public float floatSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate the trophy
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Floating up and down
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPosition + Vector3.up * yOffset;
    }
}