using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public Vector3 offset; // Offset from the player position

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
