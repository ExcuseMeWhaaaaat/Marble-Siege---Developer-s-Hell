using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitchChecking : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    
    public static SceneSwitchChecking instance;
    public string expectedScene;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    public void CheckOnScene()
    {
            if (SceneManager.GetActiveScene().name != expectedScene)
                dialogueText.text = "";
        
        
        
    }

}
