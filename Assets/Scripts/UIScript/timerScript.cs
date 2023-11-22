using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    private float currentTime = 0.0f; // Start from 0
    public static bool isTimerRunning = false;

    public Text timerText; 

    void Start()
    {
        isTimerRunning = true;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime; // Increment time

            // Display the updated time in the Text component
            timerText.text = "Time:" + currentTime.ToString("F1"); // Display one decimal place
        }
    }
}
