using System.Collections;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public GameObject waterOrder;
    public GameObject juiceOrder;

    void Start()
    {
        StartCoroutine(WaterOrderActivate());
        StartCoroutine(JuiceOrderActivate());
    }

    private IEnumerator WaterOrderActivate()
    {
        float delay = Random.Range(3f, 6f); // Random time between 3 and 8 seconds
        yield return new WaitForSeconds(delay);

        waterOrder.SetActive(true); // Activate the GameObject
    }

    private IEnumerator JuiceOrderActivate()
    {
        float delay = Random.Range(6f, 10f); // Random time between 3 and 8 seconds
        yield return new WaitForSeconds(delay);

        juiceOrder.SetActive(true); // Activate the GameObject
    }
}
