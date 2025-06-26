using UnityEngine;

public class DriveForward : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }
}
