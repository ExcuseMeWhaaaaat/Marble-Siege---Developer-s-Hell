using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static GameManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] List<Button> buttonList;
    [SerializeField] Image backgroundImage;
    

    private void Start()
    {
        if (backgroundImage != null)
            backgroundImage.gameObject.SetActive(false);
        foreach (Button button in buttonList)
        {
            if (button != null)
                button.gameObject.SetActive(false);
        }
        if (GameManagement.instance.currentScene.ToString() == GameManagement.instance.exception) return;

    }
    public void Pause(InputAction.CallbackContext context)
    {
        
        if (!context.performed) return;
        if (GameManagement.instance.currentScene.ToString() == GameManagement.instance.exception) return;
        DetermineGameState(GameStates.Paused);
    }

    public void Resume()
    {
        
        DetermineGameState(GameStates.Playing);
    }

    public void TakeToMainMenu()
    {
        DetermineGameState(GameStates.MainMenu);
    }

    public void DetermineGameState(GameStates gameState)
    {
        Debug.Log("Called");
        GameManagement.instance.currentState = gameState;
        if (GameManagement.instance.currentScene.ToString() == GameManagement.instance.exception) return;
        switch (GameManagement.instance.currentState)
        {
            case GameStates.Playing:
                {
                    Debug.Log("Played");
                    Conditions(1,false);
                    break;
                }
            case GameStates.Paused:
                {
                    Debug.Log("Paused");
                    Conditions(0, true);
                    break;
                }
            case GameStates.MainMenu:
                {
                    Debug.Log("Main Menu");
                    Conditions(1, false);
                    break;
                }
        }
        
    }

    public void Conditions(int timedScale, bool setActiveObjects)
    {
        foreach (Button button in buttonList)
        {
            if (button != null)
                button.gameObject.SetActive(setActiveObjects);
        }
        backgroundImage.gameObject.SetActive(setActiveObjects);
        GameManagement.instance.isPaused = setActiveObjects;
        Time.timeScale = timedScale;
    }

    
}
