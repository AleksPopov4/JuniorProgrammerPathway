using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;

    public float speed;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player"); // Find the player object in the scene
    }

    private void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; // Calculate direction to player
        enemyRb.AddForce(lookDirection * speed); // Move towards the player
        if (transform.position.y < -10) // Check if the enemy falls below a certain height
        {
            Destroy(gameObject); // Destroy the enemy object
        }
    }
}
