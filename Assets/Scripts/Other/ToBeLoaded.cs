using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBeLoaded : MonoBehaviour
{
    public void ContinueGame()
    {
        string lastScene = PlayerPrefs.GetString("LastScene");

        if (!string.IsNullOrEmpty(lastScene))
        {
            SceneManager.LoadScene(lastScene);
        }
    }
}
