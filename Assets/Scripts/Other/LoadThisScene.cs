using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadThisScene : MonoBehaviour
{

    [SerializeField] string sceneName;

    private void Start()
    {
        PlayerPrefs.SetString("LastScene", sceneName);
        PlayerPrefs.Save();
    }


}
