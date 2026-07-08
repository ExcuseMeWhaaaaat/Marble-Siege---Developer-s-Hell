using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmReset : MonoBehaviour
{


    [SerializeField] Image confirmImage;
    public void ResetGame()
    {
        GameManagement.instance.gameLoaded = false;
        PlayerPrefs.SetString("Prelude", LoadThisScene.instance.allowedScene);
        
        Debug.Log("Resetted Game");
        confirmImage.gameObject.SetActive(false);
        
    }

    

}
