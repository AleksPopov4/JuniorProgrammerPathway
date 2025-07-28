using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint; // Reference to the focal point object

    public float speed = 5f;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point"); // Find the focal point object in the scene
    }

    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical"); // Get vertical input (W/S keys or Up/Down arrows)
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }
}
