using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float backgroundRepeatWidth;

    private void Start()
    {
        startPosition = transform.position;
        backgroundRepeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
        if (transform.position.x < startPosition.x - backgroundRepeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
