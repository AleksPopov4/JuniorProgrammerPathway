using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue; // Points awarded for hitting this target
    public ParticleSystem explosionParticle; // Particle effect for explosion

    private Rigidbody targetRb;
    private GameManager gameManager;

    private float minSpeed = 12f;
    private float maxSpeed = 15f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -2f;
    private int lostLifeValue = -1; // Value for losing a life

    private void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.UpdateLives(lostLifeValue);
        }
    }
}
