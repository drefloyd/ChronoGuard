using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class waveScript : MonoBehaviour
{
    private static TextMeshProUGUI waveText;

    public static int waveNumber = 1;  // start at wave 1

    void Awake()
    {
        waveText = GameObject.Find("WaveDisplay").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        waveText.text = ("Wave:"+ 1);
    }

    public static void increaseWave()
    {
        waveNumber++;

        waveText.text = ("Wave:" + waveNumber);
    }
}