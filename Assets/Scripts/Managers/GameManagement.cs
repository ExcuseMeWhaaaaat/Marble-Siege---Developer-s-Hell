using NUnit.Framework;
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
