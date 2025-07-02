using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField]
    private FloatSO goldSO; // ScriptableObject to hold gold value
    [SerializeField]
    private TextMeshProUGUI goldText; // Reference to the UI Text component to display gold amount
    private bool gameOver;

    void Update()
    {
        goldText.text = "Gold: " + goldSO.Value;
        if (goldSO.Value >= 100 && !gameOver)
        {
            gameOver = true;
            //OnGameOver();
            Debug.Log("You have reached 100 gold!");
        }
    }
}
