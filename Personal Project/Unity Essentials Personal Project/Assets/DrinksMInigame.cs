using UnityEngine;

public class DrinksMInigame : MonoBehaviour
{
    [SerializeField]
    private FloatSO goldSO; // ScriptableObject to hold gold value

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            goldSO.Value += 10; 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            goldSO.Value += 20; 
        }
    }
}
