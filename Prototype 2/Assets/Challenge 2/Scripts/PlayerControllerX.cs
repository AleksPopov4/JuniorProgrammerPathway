using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canInstantiate = true;

    // Update is called once per frame
    void Update()
    {
        if (canInstantiate)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                StartCoroutine(DisableInputForAWhile());
            }
        }
    }

    IEnumerator DisableInputForAWhile()
    {
        canInstantiate = false;
        yield return new WaitForSeconds(1f);
        canInstantiate = true;
    }
}
