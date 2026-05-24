using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManagement : MonoBehaviour
{
    public static SaveManagement instance;
    

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    
    
    
    

    


}
