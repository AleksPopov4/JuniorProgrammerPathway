using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed; // Speed of camera rotation

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D keys or Left/Right arrows)
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
