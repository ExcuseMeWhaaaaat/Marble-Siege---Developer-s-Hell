using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;
    public string exception;
    public bool isPaused;
    public bool gameLoaded;



    public Scene currentScene;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this); 
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        
    }

    public static event Action OnGameReset;

    // Call this method when the player clicks "Restart" or dies
    public void ResetTheGame()
    {
        // The ?.Invoke() checks if anyone is listening before firing
        OnGameReset?.Invoke();
    }


    public enum GameStates 
    {
        Playing,
        Paused,
        MainMenu,
        GameOver,
    }

    public GameStates currentState;
    
    

    
    public void GameLoadedFilter()
    {
        if (gameLoaded) return;
        gameLoaded = true;
    }
    

    
}
