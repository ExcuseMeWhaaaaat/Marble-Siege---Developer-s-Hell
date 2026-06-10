using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakeToScene : MonoBehaviour
{
    public Button thisButton;
    public string targetScene;
    
    public static TakeToScene instance;
    public Scene currentScene;

    private void Start()
    {
        
        currentScene = SceneManager.GetActiveScene();
        
        
    }
    public void SceneChange()
    {
        SceneManager.LoadScene(targetScene);
        Conditions(); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void CheckForScene()
    {
        if(instance != null)
        {
            SceneSwitchChecking.instance.CheckOnScene();
            if (targetScene == "MainMenu")
            QuitGame();  
        }
        
    
    }

    

    

    public void Conditions()
    {
        if (SoundManagement.instance != null)
        {
            SoundManagement.PlaySound(SoundType.Click, 0.5f);
        }
        CheckForScene();
    }
}
