using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class waveScript : MonoBehaviour
{
    public Text waveText;

    public static int waveNumber = 1;  // start at wave 1

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