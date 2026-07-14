using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakeToScene : MonoBehaviour
{
    public Button thisButton;
    public string targetScene;
    
    public static TakeToScene instance;
    [SerializeField] private OpenResetPanel openResetPanel;
    [SerializeField] TextMeshProUGUI confirmText;
    public bool confirmable = false;
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

    public void ShouldGameReset()
    {
        if (LoadThisScene.instance.currentScene != "MainMenu")
        return;
        

        if (LoadThisScene.instance.allowedScene != "Prelude" && GameManagement.instance.gameLoaded)
        {
            if (openResetPanel == null) return;
            openResetPanel.OpenReseter();
        }
        else
        {
            SceneChange();
            GameManagement.instance.GameLoadedFilter();
            
        }
    }

    public void ConfirmSkip()
    {
        
        if (confirmable)
        {
            Debug.Log("Can skip!");
            SceneChange();
        }
        else
        {
            Ensure();
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

    public void Ensure()
    {
        confirmText.text = "U sure?";
        confirmable = true;
    }
}
