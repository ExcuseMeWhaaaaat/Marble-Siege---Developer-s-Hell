using Unity.Play.Publisher.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadThisScene : MonoBehaviour
{
    public string currentScene;
    
    public string allowedScene;
    public static LoadThisScene instance;
    

    private void Awake()
    {
        if (instance == null)
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
        allowedScene = "Prelude";
    }

    public void SaveScene()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (GameManagement.instance.gameLoaded)
        {
            if(currentScene != "MainMenu")
            {
                allowedScene = currentScene;
            }
            
        }
        PlayerPrefs.SetString("LastScene", allowedScene);
        PlayerPrefs.Save();
    }

    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        SaveScene();
    }

    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
