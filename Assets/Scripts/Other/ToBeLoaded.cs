using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToBeLoaded : MonoBehaviour
{
    
    
    public void ContinueGame()
    {
        string lastScene = PlayerPrefs.GetString("LastScene");

        if (string.IsNullOrEmpty(lastScene))
        {
            return;
        }
        else
        {
            SceneManager.LoadScene(lastScene);
        }
    }

    


}
