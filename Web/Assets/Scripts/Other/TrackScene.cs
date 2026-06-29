using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackScene : MonoBehaviour
{

    public static TrackScene instance;
    
    public string currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void OnEnable()
    {
        
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }
}
