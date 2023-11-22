using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public float playerScore = 0; 

    private float scorePerKill = 10;

    public Text scoreText; 

    public void increaseScore()
    {
        playerScore += scorePerKill;
        scoreText.text = "Score:" + playerScore.ToString();
    }
}
