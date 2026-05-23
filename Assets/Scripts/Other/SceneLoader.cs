using Unity.VectorGraphics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    private void Start()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
    
}
