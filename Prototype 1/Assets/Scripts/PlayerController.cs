using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f; // Speed of the player movement
    private float turnSpeed = 45.0f; // Speed of the player turning
    private float horizontalInput; // Input for horizontal movement
    private float forwardInput; // Input for forward movement 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input from the player
        forwardInput = Input.GetAxis("Vertical"); // Get vertical input from the player

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); // Rotate the player based on horizontal input
    }
}
