using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static bool gameisPaused = false;
    public GameObject pauseMenuUI;
    public GameObject PlayerUI;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenuUI.activeInHierarchy)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false); 
        PlayerUI.SetActive(true);
        Time.timeScale = 1f;
        gameisPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        PlayerUI.SetActive(false);
        Time.timeScale = 1f;
        gameisPaused = true;
    }
}
