using UnityEngine;

public class PlsSpareDis2 : MonoBehaviour
{
    public static PlsSpareDis2 buttonInstance;
    private void Awake()
    {
        if (buttonInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        buttonInstance = this;
        DontDestroyOnLoad(this.gameObject);

    }
}
