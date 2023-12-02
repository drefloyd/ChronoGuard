using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveOneTutorial : MonoBehaviour
{
    private TextMeshProUGUI tutorialText;
    // Start is called before the first frame update
    void Awake()
    {
        tutorialText = GameObject.Find("TutorialLabel").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waveScript.waveNumber >1)//change it to empty once we finish wave 1
        {
            tutorialText.text = string.Empty;
        }
        
    }
}
