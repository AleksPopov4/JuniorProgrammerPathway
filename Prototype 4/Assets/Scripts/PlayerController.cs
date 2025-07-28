using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint; // Reference to the focal point object
    private bool hasPowerup; // Track if the player has a power
    private float powerupStrength = 5f; // Strength of the powerup effect

    public float speed = 5f;
    public GameObject powerupIndicator; // Reference to the powerup indicator object

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point"); // Find the focal point object in the scene
    }

    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical"); // Get vertical input (W/S keys or Up/Down arrows)
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); // Position the powerup indicator below the player
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true); // Activate the powerup indicator
            StartCoroutine(PowerupCountdownRoutine()); // Start the powerup countdown
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.transform.position - transform.position;

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to" + hasPowerup);
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); // Wait for 7 seconds
        hasPowerup = false; // Reset powerup status
        powerupIndicator.SetActive(false); // Deactivate the powerup indicator
        Debug.Log("Powerup has ended");
    }
}
