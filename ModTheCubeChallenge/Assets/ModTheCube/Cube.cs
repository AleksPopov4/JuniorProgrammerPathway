using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public float cubePositionX;
    public float cubePositionY;
    public float cubePositionZ;

    public float cubeRotationSpeed;

    public float cubeColorR;
    public float cubeColorG;
    public float cubeColorB;
    public float cubeColorA;

    public float cubeRotationX;
    public float cubeRotationY;
    public float cubeRotationZ;


    [SerializeField] private float duration = 2f; // seconds per transition
    private Renderer cubeRenderer;

    void Start()
    {
        var cubeScale = Random.Range(3f, 8f);
        transform.position = new Vector3(cubePositionX, cubePositionY, cubePositionZ);
        transform.localScale = Vector3.one * cubeScale;
        cubeRenderer = GetComponent<Renderer>();
        StartCoroutine(CycleColors());
    }

    void Update()
    {
        transform.Rotate(cubeRotationX * Time.deltaTime, cubeRotationY, cubeRotationZ);
    }

    private IEnumerator CycleColors()
    {
        // Define the color cycle
        Color[] colors = new Color[] {
            Color.red,
            Color.yellow,
            Color.blue,
            Color.red // loop back to red
        };

        int index = 0;

        while (true) // loop forever
        {
            Color from = colors[index];
            Color to = colors[(index + 1) % colors.Length];

            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime / duration;
                cubeRenderer.material.color = Color.Lerp(from, to, t);
                yield return null;
            }

            index = (index + 1) % colors.Length;
        }
    }
}
