using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class waveScript : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    public static int waveNumber = 1;  // start at wave 1

    void Awake()
    {
        waveText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        waveText.text = ("Wave:"+ 1);
    }

    public static void increaseWave()
    {
        waveNumber++;

        Text waveText = GameObject.Find("WaveDisplay").GetComponent<Text>();
        waveText.text = ("Wave:" + waveNumber);
    }
}