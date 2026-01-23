using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 150f;

    void Update()
    {
        float move = Input.GetAxis("Vertical");     // W / S
        float rotate = Input.GetAxis("Horizontal"); // A / D

        // Move forward & backward
        transform.Translate(Vector3.forward * move * moveSpeed * Time.deltaTime);

        // Rotate left & right
        transform.Rotate(Vector3.up * rotate * rotationSpeed * Time.deltaTime);
    }
}
