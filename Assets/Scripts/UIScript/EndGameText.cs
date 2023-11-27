using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EndGameText : MonoBehaviour
{
    public GameObject WinnerUI;
    public GameObject LoserUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        LoserUI.SetActive(true);
        scoreText.text = scoreScript.playerScore.ToString();
        timeText.text = timerScript.stopTime.ToString("F1");
    }

}
