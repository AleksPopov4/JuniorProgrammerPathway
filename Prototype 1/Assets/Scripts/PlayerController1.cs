using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private float speed = 20.0f; // Speed of the player movement
    private float turnSpeed = 45.0f; // Speed of the player turning
    private float horizontalInput; // Input for horizontal movement
    private float forwardInput; // Input for forward movement 
    private GameObject mainCamera; // Reference to the main camera
    private GameObject driverCamera; // Reference to the driver camera

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera1");
        driverCamera = GameObject.Find("Driver Camera1");
        driverCamera.SetActive(false); // Ensure the driver camera is inactive at the start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (mainCamera != null && driverCamera != null)
            {
                mainCamera.SetActive(true); // Activate the main camera
                driverCamera.SetActive(false); // Deactivate the driver camera
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (mainCamera != null && driverCamera != null)
            {
                driverCamera.SetActive(true); // Activate the driver camera
                mainCamera.SetActive(false); // Deactivate the main camera
            }
        }

        horizontalInput = Input.GetAxis("Horizontal1"); // Get horizontal input from the player
        forwardInput = Input.GetAxis("Vertical1"); // Get vertical input from the player

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); // Rotate the player based on horizontal input
    }
}
