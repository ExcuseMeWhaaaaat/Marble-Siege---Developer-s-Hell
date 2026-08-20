using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static GameManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] List<Button> buttonList;
    
    
    [SerializeField] private ToggleSettingsMenu toggleSettingsMenu;

    
    
    private void Start()
    {
        
        foreach (Button button in buttonList)
        {
            if (button != null)
                button.gameObject.SetActive(false);
        }
        if (GameManagement.instance.currentScene.ToString() == GameManagement.instance.exception) return;

    }
    public void Pause(InputAction.CallbackContext context)
    {
        
        if (!context.performed || toggleSettingsMenu.isVisible) return;
        if (GameManagement.instance.currentScene.ToString() == GameManagement.instance.exception) return;
        SoundManagement.PlaySound(SoundType.Click, SoundManagement.instance.masterVol);
        DetermineGameState(GameStates.Paused);
        
    }

    public void Resume()
    {
        if (GameManagement.instance.currentState == GameManagement.GameStates.Playing) return;
        
        Debug.Log(toggleSettingsMenu);

        toggleSettingsMenu.TurnOff();   
        SoundManagement.PlaySound(SoundType.Click,SoundManagement.instance.masterVol);
          
        DetermineGameState(GameStates.Playing);
        
        
    }

    public void TakeToMainMenu()
    {
        DetermineGameState(GameStates.MainMenu);
        SoundManagement.PlaySound(SoundType.Click, SoundManagement.instance.masterVol);
        toggleSettingsMenu.settingsCanvas.gameObject.SetActive(false);
        
    }

    public void DetermineGameState(GameStates gameState)
    {
        
        GameManagement.instance.currentState = gameState;
        if (GameManagement.instance.currentScene.ToString() == GameManagement.instance.exception) return;
        switch (GameManagement.instance.currentState)
        {
            case GameStates.Playing:
                {
                    
                    Conditions(1,false);
                    
                    
                    break;
                }
            case GameStates.Paused:
                {
                    
                    Conditions(0, true);
                    break;
                }
            case GameStates.MainMenu:
                {
                    
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
        
        GameManagement.instance.isPaused = setActiveObjects;
        Time.timeScale = timedScale;
        
    }

}
