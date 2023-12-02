using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
        public void PlayGame()
    {
        Time.timeScale = 1f;
        pauseMenu.gameisPaused = false;
        timerScript.isTimerRunning = true;
        scoreScript.playerScore = 0;
        waveScript.waveNumber = 1;
        scoreScript.scoreThreshold = 50;
        scoreScript.resetDroneStats();
        SceneManager.LoadSceneAsync(1);
    }

    public void MainScreen()
    {
        Time.timeScale = 1f;
        timerScript.isTimerRunning = false;
        waveScript.waveNumber = 1;
        scoreScript.playerScore = 0;
        SceneManager.LoadSceneAsync(0);
    }
}
