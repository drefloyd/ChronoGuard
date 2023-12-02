using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using static UnityEngine.InputSystem.HID.HID;

public class pauseMenu : MonoBehaviour
{
    public static bool gameisPaused;
    public GameObject pauseMenuUI;
    public GameObject optionUI;
    public GameObject controlUI;
    public Button controlButton;
    public GameObject PlayerUI;
    public Button optionButton;
    public Sprite selectedSprite;
    public Sprite highlightedSprite;
    public Sprite disabledSprite;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeInHierarchy)
            {
                Resume();
                
            }
            else if (optionUI.activeInHierarchy)
            {
                Resume();

            }
            else if (controlUI.activeInHierarchy)
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
        optionUI.SetActive(false);
        controlUI.SetActive(false);
        PlayerUI.SetActive(true);
        Time.timeScale = 1f;
        gameisPaused = false;
        timerScript.isTimerRunning = true;
        Selectable.Transition buttonTransition = controlButton.transition;
        controlButton.transition =Selectable.Transition.SpriteSwap;
        controlButton.transition = buttonTransition;
        SpriteState spriteState = new SpriteState
        {
            selectedSprite = disabledSprite,
            highlightedSprite=highlightedSprite,
            pressedSprite=selectedSprite
            // You can set other sprite states (highlightedSprite, pressedSprite) if needed
        };

        controlButton.spriteState = spriteState;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        PlayerUI.SetActive(false);
        Time.timeScale = 1f;
        gameisPaused = true;
        timerScript.isTimerRunning = false;
    }
    public void Option()
    {
        optionUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Selectable.Transition buttonTransition = optionButton.transition;
        optionButton.transition =Selectable.Transition.SpriteSwap;
        optionButton.transition = buttonTransition;
        SpriteState spriteState = new SpriteState
        {
            selectedSprite = disabledSprite,
            highlightedSprite=highlightedSprite,
            pressedSprite=selectedSprite
            // You can set other sprite states (highlightedSprite, pressedSprite) if needed
        };

        optionButton.spriteState = spriteState;
    }
}