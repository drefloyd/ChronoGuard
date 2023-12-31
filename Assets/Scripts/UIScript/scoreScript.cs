using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class scoreScript : MonoBehaviour
{
    public static float playerScore = 0;
    private float scorePerKill = 10;
    private TextMeshProUGUI scoreText;

    public static float scoreThreshold = 50;    // start at 5 kills to increase (5 kills == 50 points)

    public GameObject robotGuardianPrefab;
    public GameObject robotInvaderPrefab;
    public GameObject robotRockiePrefab;

    void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        scoreText.text = ("Score:0");
        playerScore = 0;
        scoreThreshold = 50;
    }
    public void increaseScore()
    {
        playerScore += scorePerKill;
        scoreText.text = "Score:" + playerScore.ToString();

        if (playerScore == scoreThreshold)     // once player score reaches the score threshold
        {
            DroneController.speed += 0.1f;    // increase drone speed each wave
            scoreThreshold += 50;  // increase kill threshold by 5

           DroneSpawner.spawnInterval -= 0.03f; // make drones spawn faster each wave

           waveScript.increaseWave();
        }
    }

    public static void resetDroneStats()
    {
        DroneController.speed = .15f;    
        DroneSpawner.spawnInterval = 1.8f;
    }
}