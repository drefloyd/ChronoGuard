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

        SceneManager.LoadSceneAsync(1);
    }
    public void MainScreen()
    {
        Time.timeScale = 1f;
        timerScript.isTimerRunning = false;
        SceneManager.LoadSceneAsync(0);
    }
}
