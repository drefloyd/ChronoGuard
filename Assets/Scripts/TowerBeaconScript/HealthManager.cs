using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public string towerTag = "Tower";
    public string beaconTag = "Beacon";
    AudioManager audioManager;

    void Awake()
    {
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }
    void Update()
    {
        // Check if all game objects with the specified tag are destroyed
        if (GameObject.FindGameObjectsWithTag(towerTag).Length == 0||GameObject.FindGameObjectsWithTag(beaconTag).Length == 0)
        {
            timerScript.isTimerRunning=false;
            // All objects are destroyed, transition to the next scene
            SceneManager.LoadScene(2);
            audioManager.PlaySFX(audioManager.GameOver);

        }
    }
}
