using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class timerScript : MonoBehaviour
{
    public float currentTime = 0.0f; // Start from 0
    public static bool isTimerRunning = false;
    public TextMeshProUGUI timerText;
    public static float stopTime = 0.0f;
    void Awake()
    {
        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

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
        else if (isTimerRunning==false)
        {
            stopTime= currentTime;

        }
    }
}