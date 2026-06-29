using Unity.VisualScripting;
using UnityEngine;

public class PlsSpare : MonoBehaviour
{
    public static PlsSpare instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }




}
