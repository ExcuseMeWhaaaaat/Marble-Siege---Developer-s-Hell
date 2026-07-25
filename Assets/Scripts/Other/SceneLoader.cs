using Unity.VectorGraphics;
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
