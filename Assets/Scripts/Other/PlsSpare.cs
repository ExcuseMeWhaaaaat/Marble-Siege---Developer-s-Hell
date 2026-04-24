using Unity.VisualScripting;
using UnityEngine;

public class PlsSpare : MonoBehaviour
{
    public static PlsSpare instance;
    private void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        
    }




}
