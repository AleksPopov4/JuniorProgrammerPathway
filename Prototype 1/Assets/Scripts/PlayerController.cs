using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f; // Speed of the player movement
    [SerializeField] private float turnSpeed = 45.0f; // Speed of the player turning
    [SerializeField] private float horizontalInput; // Input for horizontal movement
    [SerializeField] private float forwardInput; // Input for forward movement 
    [SerializeField] private GameObject mainCamera; // Reference to the main camera
    [SerializeField] private GameObject driverCamera; // Reference to the driver camera

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        driverCamera = GameObject.Find("Driver Camera");
        driverCamera.SetActive(false); // Ensure the driver camera is inactive at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (mainCamera != null && driverCamera != null)
            {
                mainCamera.SetActive(true); // Activate the main camera
                driverCamera.SetActive(false); // Deactivate the driver camera
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (mainCamera != null && driverCamera != null)
            {
                driverCamera.SetActive(true); // Activate the driver camera
                mainCamera.SetActive(false); // Deactivate the main camera
            }
        }

        horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input from the player
        forwardInput = Input.GetAxis("Vertical"); // Get vertical input from the player

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); // Rotate the player based on horizontal input
    }
}
